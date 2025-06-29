using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Services.Categories
{
    public interface ICategoriesAppService
    {
        Task<GetAllCategoryDto> GetAllAsync(FilterInputDto filter);
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task CreateOrEditAsync(CreateOrEditCategoryDto input);
        Task DeleteAsync(Guid id);
    }
}