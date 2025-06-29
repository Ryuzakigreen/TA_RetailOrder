using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<(IEnumerable<Customer> Items, int TotalCount)> GetAllAsync(GetCustomerFilterInputDto filter);
        Task<Customer> GetByIdAsync(Guid id);
        Task DeleteByIdAsync(Guid id);
        Task UpdateAsync(Customer customer);
        Task<int> SaveChangesAsync();
    }
}