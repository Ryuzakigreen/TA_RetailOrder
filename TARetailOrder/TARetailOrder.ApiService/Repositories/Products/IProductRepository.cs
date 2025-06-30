using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Products.DTOs;

namespace TARetailOrder.ApiService.Repositories.Products
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Product> Items, int TotalCount)> GetAllAsync(FilterInputDto filter);
        Task<Product> GetByIdAsync(Guid id);
        Task InsertAsync(Product input);
        Task UpdateAsync(Product input);
        Task DeleteByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}