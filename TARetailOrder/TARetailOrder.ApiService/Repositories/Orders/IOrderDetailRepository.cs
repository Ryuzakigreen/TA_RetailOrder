using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Repositories.Orders
{
    public interface IOrderDetailRepository
    {
        Task<(IEnumerable<OrderDetail> Items, int TotalCount)> GetAllByPageAsync(FilterInputDto filter);
        Task<Dictionary<Guid, OrderDetail>> GetAllDetailAsync();
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail> GetByIdAsync(Guid id);
        Task InsertAsync(OrderDetail input);
        Task InsertRangeAsync(List<OrderDetail> input);
        Task UpdateAsync(OrderDetail input);
    }
}