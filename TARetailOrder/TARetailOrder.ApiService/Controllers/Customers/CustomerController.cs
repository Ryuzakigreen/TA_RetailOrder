using Microsoft.AspNetCore.Mvc;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Customers;
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

        [HttpPost("GetAllAsync")]
        public async Task<ActionResult<List<GetAllCustomerDto>>> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                _logger.LogInformation("Retrieving all customers");

                var customers = await _customersAppService.GetAllAsync(filter);
                if(customers.SummaryResult.TotalCount == 0)
                {
                    _logger.LogInformation("No Records");
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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            try
            {
                _logger.LogInformation("Retrieving all customers");

                var customer = await _customersAppService.GetByIdAsync(id);
                if (customer == null)
                {
                    _logger.LogInformation("No Record");
                    return Ok(new GetAllCustomerDto());
                }
                _logger.LogInformation("Successfully retrieved customer {0}.",id);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve customer. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("CreateOrEdit")]
        public async Task<ActionResult> CreateOrEdit(CreateOrEditCustomerDto input)
        {
            try
            {
                await _customersAppService.CreateOrEditAsync(input);
                _logger.LogInformation("Successfully saved customer.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve customer. Error: {ErrorMessage}", ex.Message);

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
                await _customersAppService.DeleteAsync(id);
                _logger.LogInformation("Successfully deleted customer {0}.", id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve customer. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
