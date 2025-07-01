using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Services.Orders
{
    public interface IOrderAppService
    {
        Task<Guid?> Create(CreateOrderDto input);
        Task<GetOrderByHeaderDto> GetByOrderIdAsync(Guid Id);
        Task<GetOrderByHeaderDto> GetByCustomerIdAsync(Guid Id);
        Task<string> UpdateStatusAsync(UpdateOrderStatusDto input);
    }
}