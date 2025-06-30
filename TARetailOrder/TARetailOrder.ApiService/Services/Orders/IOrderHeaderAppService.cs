using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Services.Orders
{
    public interface IOrderHeaderAppService
    {
        Task<GetAllOrderHeaderDto> GetAllByPageAsync(FilterInputDto filter);
        Task<ViewOrderHeaderDto> GetByIdAsync(Guid? headerId, Guid? customerId);
        Task<Guid?> CreateOrEditAsync(CreateOrEditOrderHeaderDto input);
    }
}