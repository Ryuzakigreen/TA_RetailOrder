using TARetailOrder.ApiService.Services.Products.DTOs;

namespace TARetailOrder.ApiService.Services.Products
{
    public interface IProductsAppService
    {
        Task<GetAllProductDto> GetAllAsync(FilterInputDto filter);
        Task<ViewProductDto> GetByIdAsync(Guid id);
        Task CreateOrEditAsync(CreateOrEditProductDto input);
        Task DeleteAsync(Guid id);
    }
}