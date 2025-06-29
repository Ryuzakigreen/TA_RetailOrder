using Microsoft.AspNetCore.Mvc;
using TARetailOrder.ApiService.Services.Customer;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Controllers.Customers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersAppService _customersAppService;
        private readonly ILogger<CustomersAppService> _logger;
        public CustomerController(
            ICustomersAppService customersAppService, 
            ILogger<CustomersAppService> logger)
        {
            _customersAppService = customersAppService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<List<GetAllCustomerDto>>> GetAllAsync(GetCustomerFilterInputDto filter)
        {
            try
            {
                _logger.LogInformation("Retrieving all customers");

                var customers = await _customersAppService.GetAllAsync(filter);
                if(customers.SummaryResult.TotalCount == 0)
                {
                    _logger.LogInformation("No Customer Record");
                    return Ok(new GetAllCustomerDto());
                }
                _logger.LogInformation("Successfully retrieved {CustomerCount} customers", customers.SummaryResult.TotalCount);

                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve customers. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
