using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Services.Orders
{
    public interface IOrderDetailAppService
    {
        Task<GetAllOrderDetailDto> GetAllAsync(FilterInputDto filter);
        Task<List<ViewOrderDetailDto>> GetByHeaderIdAsync(Guid headerId);
        Task<ViewOrderDetailDto> GetByIdAsync(Guid id);
        Task CreateOrEditAsync(CreateOrEditOrderDetailDto input);
        Task CreateRangeAsync(List<CreateOrEditOrderDetailDto> input);
    }
}