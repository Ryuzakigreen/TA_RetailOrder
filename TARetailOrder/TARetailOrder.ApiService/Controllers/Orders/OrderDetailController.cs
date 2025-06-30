using Microsoft.AspNetCore.Mvc;
using TARetailOrder.ApiService.Controllers.Products;
using TARetailOrder.ApiService.Services.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;
using TARetailOrder.ApiService.Services.Products;
using TARetailOrder.ApiService.Services.Products.DTOs;

namespace TARetailOrder.ApiService.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrderDetailController : ControllerBase
    {
       
        private readonly IOrderAppService _orderAppService;
        private readonly ILogger<OrderDetailController> _logger;
        public OrderDetailController(IOrderAppService orderAppService,
            ILogger<OrderDetailController> logger)
        {
            _orderAppService = orderAppService;
            _logger = logger;
        }

    }
}
