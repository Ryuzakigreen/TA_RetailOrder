using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TARetailOrder.ApiService.Controllers.Products;
using TARetailOrder.ApiService.Services.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderAppService orderAppService,
            ILogger<OrderController> logger)
        {
            _orderAppService = orderAppService;
            _logger = logger;
        }

        [HttpPost("orders")]
        public async Task<ActionResult<Guid?>> Create(CreateOrderDto input)
        {
            try
            {
                await _orderAppService.Create(input);
                _logger.LogInformation("Successfully saved order.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve order. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("orders/{orderId}")]
        public async Task<ActionResult<GetOrderByHeaderDto>> GetByOrderId(Guid orderId)
        {
            try
            {
                _logger.LogInformation("Retrieving all products");

                var orders = await _orderAppService.GetByOrderIdAsync(orderId);
                if (orders == null)
                {
                    _logger.LogInformation("No Record");
                    return Ok(new GetOrderByHeaderDto());
                }
                _logger.LogInformation("Successfully retrieved order {0}.", orderId);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve order. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("order/customer/{id}")]
        public async Task<ActionResult<GetOrderByHeaderDto>> GetByCustomerId(Guid id)
        {
            try
            {
                _logger.LogInformation("Retrieving all orders");

                var orders = await _orderAppService.GetByCustomerIdAsync(id);
                if (orders == null)
                {
                    _logger.LogInformation("No Record");
                    return Ok(new GetOrderByHeaderDto());
                }
                _logger.LogInformation("Successfully retrieved order {0}.", id);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve order. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("orderstatus")]
        public async Task<ActionResult<String>> UpdateStatus(UpdateOrderStatusDto input)
        {
            try
            {
                string msg = await _orderAppService.UpdateStatusAsync(input);

                return Ok(msg);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update status order. Error: {ErrorMessage}", ex.Message);

                return Problem(
                    title: "Internal Server Error",
                    detail: "An error occurred while processing your request",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
