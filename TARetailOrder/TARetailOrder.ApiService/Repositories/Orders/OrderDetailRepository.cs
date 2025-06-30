using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Repositories.Orders
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DBDataContext _db;
        private readonly ILogger<OrderDetailRepository> _logger;
        public OrderDetailRepository(DBDataContext db, ILogger<OrderDetailRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<(IEnumerable<OrderDetail> Items, int TotalCount)> GetAllByPageAsync(FilterInputDto filter)
        {
            try
            {
                var qry = _db.OrderDetail
                .Include(e => e.ProductFk)
                .Include(e => e.OrderHeaderFk)
                .OrderByDescending(x=> x.CreationTime);

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
        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            try
            {
                return _db.OrderDetail
                .Include(e => e.ProductId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetAllAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task<OrderDetail> GetByIdAsync(Guid id)
        {
            try
            {
                return await _db.OrderDetail
                    .Include(e => e.ProductFk)
                    .Include(e => e.OrderHeaderFk)
                    .FirstOrDefaultAsync(e => e.ID == id) ?? new OrderDetail();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetByIdAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task InsertAsync(OrderDetail input)
        {
            try
            {

                input.CreationTime = DateTime.UtcNow;
                input.CreatorUserId = 0;
                await _db.OrderDetail.AddAsync(input);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute AddAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }
        public async Task InsertRangeAsync(List<OrderDetail> input)
        {
            try
            {
                var items = new List<OrderDetail>(input);
                foreach (var item in items)
                {
                    item.CreationTime = DateTime.UtcNow;
                    item.CreatorUserId = 0;
                }
                
                await _db.OrderDetail.AddRangeAsync(items);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute AddAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task UpdateAsync(OrderDetail input)
        {
            try
            {
                input.LastModificationTime = DateTime.UtcNow;
                input.LastModifierUserId = 0;
                _db.OrderDetail.Update(input);
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
