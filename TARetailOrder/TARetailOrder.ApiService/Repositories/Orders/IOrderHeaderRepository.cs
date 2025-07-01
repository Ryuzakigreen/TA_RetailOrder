using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Repositories.Orders
{
    public interface IOrderHeaderRepository
    {
        Task<(IEnumerable<OrderHeader> Items, int TotalCount)> GetAllByPageAsync(FilterInputDto filter);
        Task<Dictionary<Guid, OrderHeader>> GetAllHeaderAsync();
        Task<IEnumerable<OrderHeader>> GetAllAsync();
        Task<OrderHeader> GetByIdAsync(Guid id);
        Task<Guid> InsertAsync(OrderHeader input);
        Task<string> UpdateAsync(OrderHeader input);
        Task<int> SaveChangesAsync();
    }
}