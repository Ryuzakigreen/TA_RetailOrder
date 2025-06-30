using Microsoft.EntityFrameworkCore;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Categories;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBDataContext _db;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(DBDataContext db, ILogger<CategoryRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<(IEnumerable<Category> Items, int TotalCount)> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                var qry = _db.Category
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

        public async Task<Category> GetByIdAsync(Guid id)
        {
            try
            {
                var qry = await _db.Category.FindAsync(id);
                if(qry == null)
                {
                    return new Category();
                }
                return qry.IsDeleted ? new Category(): qry;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute GetByIdAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task InsertAsync(Category input)
        {
            try
            {
                input.CreationTime = DateTime.UtcNow;
                input.CreatorUserId = 0;
                input.IsDeleted = false;
                await _db.Category.AddAsync(input);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to Execute AddAsync. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task UpdateAsync(Category input)
        {
            try
            {
                input.LastModificationTime = DateTime.UtcNow;
                input.LastModifierUserId = 0;
                _db.Category.Update(input);
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
                var category = await _db.Category.FindAsync(id);
                if (category != null)
                {
                    category.IsDeleted = true;
                    category.DeletionTime = DateTime.UtcNow;
                    category.DeleterUserId = 0;
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
