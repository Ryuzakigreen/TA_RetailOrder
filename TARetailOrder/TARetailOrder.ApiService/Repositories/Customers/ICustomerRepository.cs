using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<(IEnumerable<Customer> Items, int TotalCount)> GetAllAsync(FilterInputDto filter);
        Task<Customer> GetByIdAsync(Guid id);
        Task InsertAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteByIdAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}