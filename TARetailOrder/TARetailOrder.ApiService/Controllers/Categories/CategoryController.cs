using Microsoft.AspNetCore.Mvc;
using TARetailOrder.ApiService.Services.Categories;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Controllers.Categories
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesAppService _categoriesAppService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(
            ICategoriesAppService categoriesAppService, 
            ILogger<CategoryController> logger)
        {
            _categoriesAppService = categoriesAppService;
            _logger = logger;
        }

        [HttpPost("GetAllAsync")]
        public async Task<ActionResult<List<GetAllCategoryDto>>> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                _logger.LogInformation("Retrieving all customers");

                var categories = await _categoriesAppService.GetAllAsync(filter);
                if(categories.SummaryResult.TotalCount == 0)
                {
                    _logger.LogInformation("No Records");
                    return Ok(new GetAllCategoryDto());
                }
                _logger.LogInformation("Successfully retrieved {0} categories", categories.SummaryResult.TotalCount);

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve categories. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {
            try
            {
                _logger.LogInformation("Retrieving all category");

                var category = await _categoriesAppService.GetByIdAsync(id);
                if (category == null)
                {
                    _logger.LogInformation("No Record");
                    return Ok(new CategoryDto());
                }
                _logger.LogInformation("Successfully retrieved category {0}.", id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve category. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult> CreateOrEdit(CreateOrEditCategoryDto input)
        {
            try
            {
                await _categoriesAppService.CreateOrEditAsync(input);
                _logger.LogInformation("Successfully saved category.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve category. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _categoriesAppService.DeleteAsync(id);
                _logger.LogInformation("Successfully deleted category {0}.", id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve category. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
