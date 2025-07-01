using TARetailOrder.ApiService.Services.Products.DTOs;

namespace TARetailOrder.ApiService.Services.Products
{
    public interface IProductsAppService
    {
        Task<GetAllProductDto> GetAllByPageAsync(FilterInputDto filter);
        Task<ViewProductDto> GetByIdAsync(Guid id);
        Task CreateOrEditAsync(CreateOrEditProductDto input);
        Task DeleteAsync(Guid id);
    }
}