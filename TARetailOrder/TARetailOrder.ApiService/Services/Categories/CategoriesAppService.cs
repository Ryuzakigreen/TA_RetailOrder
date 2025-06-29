using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Repositories.Categories;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Services.Categories
{
    public class CategoriesAppService : ICategoriesAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoriesAppService> _logger;
        private readonly IMapper _mapper;
        public CategoriesAppService(
            ICategoryRepository categoryRepository, 
            ILogger<CategoriesAppService> logger,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetAllCategoryDto> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync(filter);

                if (categories.TotalCount == 0)
                {
                    _logger.LogInformation("No Category Record");
                    return new GetAllCategoryDto()
                    {
                        SummaryResult = new SummaryResult
                        {
                            Page = filter.page,
                            TotalCount = 0
                        },
                        CategoryList = new List<CategoryDto>()
                    };
                }

                _logger.LogInformation("Successfully retrieved {0} Categories", categories.TotalCount);
                return new GetAllCategoryDto
                {
                    SummaryResult = new SummaryResult
                    {
                        Page = filter.page,
                        TotalCount = categories.TotalCount
                    },
                    CategoryList = categories.Items.Select(o => new CategoryDto
                    {
                        ID = o.ID.ToString(),
                        Name = o.Name,
                        Description = o.Description,
                        Status = o.Status
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve Categories. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Category ID cannot be empty.", nameof(id));
            }
            try
            {
                var categories = await _categoryRepository.GetByIdAsync(id);
                if(categories != null)
                {
                    _logger.LogInformation("Successfully retrieved Category.");

                    return new CategoryDto()
                    {
                        ID = categories.ID.ToString(),
                        Name = categories.Name,
                        Description = categories.Description,
                        Status = categories.Status
                    };
                }
                else
                {
                    _logger.LogInformation("No record found.");
                    return new CategoryDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve Category. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Category ID cannot be empty.", nameof(id));
            }
            try
            {
                await _categoryRepository.DeleteByIdAsync(id);
                _logger.LogInformation("Successfully deleted Category.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Category. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task CreateOrEditAsync(CreateOrEditCategoryDto input)
        {
            if(input.ID == Guid.Empty)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        private async Task Create(CreateOrEditCategoryDto input)
        {
            try
            {
                var category = _mapper.Map<Category>(input);
                await _categoryRepository.InsertAsync(category);
                _logger.LogInformation("Successfully inserted Category.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Category. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
        private async Task Update(CreateOrEditCategoryDto input)
        {
            try
            {
                var category = _mapper.Map<Category>(input);
                await _categoryRepository.UpdateAsync(category);
                _logger.LogInformation("Successfully updated Category.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Category. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

    }
}
