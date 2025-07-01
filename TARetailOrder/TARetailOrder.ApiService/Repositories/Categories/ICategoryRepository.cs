using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<(IEnumerable<Category> Items, int TotalCount)> GetAllByPageAsync(FilterInputDto filter);
        Task<Category> GetByIdAsync(Guid id);
        Task InsertAsync(Category input);
        Task UpdateAsync(Category input);
        Task DeleteByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}