using Microsoft.AspNetCore.Mvc;
using TARetailOrder.ApiService.Services.Products;
using TARetailOrder.ApiService.Services.Products.DTOs;

namespace TARetailOrder.ApiService.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsAppService _productsAppService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(
            IProductsAppService productsAppService, 
            ILogger<ProductController> logger)
        {
            _productsAppService = productsAppService;
            _logger = logger;
        }

        [HttpPost("GetAllAsync")]
        public async Task<ActionResult<List<GetAllProductDto>>> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                _logger.LogInformation("Retrieving all products");

                var products = await _productsAppService.GetAllByPageAsync(filter);
                if(products.SummaryResult.TotalCount == 0)
                {
                    _logger.LogInformation("No Records");
                    return Ok(new GetAllProductDto());
                }
                _logger.LogInformation("Successfully retrieved {CustomerCount} products", products.SummaryResult.TotalCount);

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve products. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ViewProductDto>> GetById(Guid id)
        {
            try
            {
                _logger.LogInformation("Retrieving all products");

                var product = await _productsAppService.GetByIdAsync(id);
                if (product == null)
                {
                    _logger.LogInformation("No Record");
                    return Ok(new ViewProductDto());
                }
                _logger.LogInformation("Successfully retrieved product {0}.",id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve product. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult> CreateOrEdit(CreateOrEditProductDto input)
        {
            try
            {
                await _productsAppService.CreateOrEditAsync(input);
                _logger.LogInformation("Successfully saved product.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve product. Error: {ErrorMessage}", ex.Message);

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
                await _productsAppService.DeleteAsync(id);
                _logger.LogInformation("Successfully deleted product {0}.", id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve product. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
