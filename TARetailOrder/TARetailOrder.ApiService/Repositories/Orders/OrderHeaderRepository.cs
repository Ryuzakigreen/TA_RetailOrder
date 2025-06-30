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

        public async Task<IEnumerable<OrderHeader>> GetAllAsync()
        {
            try
            {
                return _db.OrderHeader.Include(e => e.CustomerId);
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

        public async Task UpdateAsync(OrderHeader input)
        {
            try
            {
                input.LastModificationTime = DateTime.UtcNow;
                input.LastModifierUserId = 0;
                _db.OrderHeader.Update(input);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute UpdateAsync. Error: {ErrorMessage}", ex.Message);
                throw;
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
