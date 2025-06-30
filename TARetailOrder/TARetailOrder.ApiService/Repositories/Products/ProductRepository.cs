using Microsoft.EntityFrameworkCore;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Products.DTOs;

namespace TARetailOrder.ApiService.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBDataContext _db;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(DBDataContext db, ILogger<ProductRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<(IEnumerable<Product> Items, int TotalCount)> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                var qry = _db.Product
                .Include(e=> e.CategoryId)
                .Where(c => !c.IsDeleted);

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

        public async Task<Product> GetByIdAsync(Guid id)
        {
            try
            {
                var qry = await _db.Product
                    .Include(e => e.CategoryId)
                    .FirstOrDefaultAsync(e=> e.ID == id);
                if(qry == null)
                {
                    return new Product();
                }
                return qry.IsDeleted ? new Product(): qry;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetByIdAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task InsertAsync(Product input)
        {
            try
            {
                input.CreationTime = DateTime.UtcNow;
                input.CreatorUserId = 0;
                input.IsDeleted = false;
                await _db.Product.AddAsync(input);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute AddAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task UpdateAsync(Product input)
        {
            try
            {
                input.LastModificationTime = DateTime.UtcNow;
                input.LastModifierUserId = 0;
                _db.Product.Update(input);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute UpdateAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task DeleteByIdAsync(Guid id)
        {
            try
            {
                var Product = await _db.Product.FindAsync(id);
                if (Product != null)
                {
                    Product.IsDeleted = true;
                    Product.DeletionTime = DateTime.UtcNow;
                    Product.DeleterUserId = 0;
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute DeleteByIdAsync. Error: {ErrorMessage}", ex.Message);
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
