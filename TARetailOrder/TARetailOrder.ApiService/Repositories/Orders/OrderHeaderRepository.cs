using Microsoft.EntityFrameworkCore;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Repositories.Orders
{
    public class OrderHeaderRepository : IOrderHeaderRepository
    {
        private readonly DBDataContext _db;
        private readonly ILogger<OrderHeaderRepository> _logger;
        public OrderHeaderRepository(DBDataContext db, ILogger<OrderHeaderRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<(IEnumerable<OrderHeader> Items, int TotalCount)> GetAllByPageAsync(FilterInputDto filter)
        {
            try
            {
                if (filter.page == 0)
                {
                    throw new ArgumentException("Page No. must greater than 0(zero)!", nameof(filter.page));
                }
                if (filter.size == 0)
                {
                    throw new ArgumentException("Page size must greater than 0(zero)!", nameof(filter.size));
                }

                var qry = _db.OrderHeader
                .Include(e => e.CustomerFk)
                .OrderByDescending(x => x.CreationTime);

                var totalCount = await qry.CountAsync();
                var items = await qry
                            .Skip((filter.page - 1) * filter.size)
                            .Take(filter.size)
                            .ToListAsync();

                return (items, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetAllAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
        public async Task<Dictionary<Guid, OrderHeader>> GetAllHeaderAsync()
        {
            try
            {
                var qry = await _db.OrderHeader
                .ToDictionaryAsync(p => p.ID, p => p);

                return qry;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetAllAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync()
        {
            try
            {
                return _db.OrderHeader.Include(e => e.CustomerFk);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetAllAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task<OrderHeader> GetByIdAsync(Guid id)
        {
            try
            {
                return await _db.OrderHeader
                    .Include(e => e.CustomerFk)
                    .FirstOrDefaultAsync(e => e.ID == id) ?? new OrderHeader();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetByIdAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task<Guid> InsertAsync(OrderHeader input)
        {
            try
            {
                if(input.ID == Guid.Empty)
                {
                    input.ID = Guid.NewGuid();
                }
                input.CreationTime = DateTime.UtcNow;
                input.CreatorUserId = 0;
                await _db.OrderHeader.AddAsync(input);
                await _db.SaveChangesAsync();

                return input.ID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute AddAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task<string> UpdateAsync(OrderHeader input)
        {
            try
            {
                
                var qry = await _db.OrderHeader.FindAsync(input.ID);
                if (qry == null)
                {
                    _logger.LogInformation("No Order Header Record Found. Unable to proceed!");
                    return "No Order Header Record Found. Unable to proceed!";
                }

                qry.CustomerId = input.CustomerId != Guid.Empty ? input.CustomerId  : qry.CustomerId;
                qry.Status = input.Status != Enums.OrderStatus.Pending ? input.Status : qry.Status;
                qry.RefNo = input.RefNo ?? qry.RefNo;
                qry.LastModificationTime = DateTime.UtcNow;
                qry.LastModifierUserId = 0;
                await _db.SaveChangesAsync();
                return "Successfully updated Order's Status.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute UpdateAsync. Error: {ErrorMessage}", ex.Message);
                return "Failed to Execute UpdateAsync.Error";
            }

        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute SaveChangesAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }
    }
}
