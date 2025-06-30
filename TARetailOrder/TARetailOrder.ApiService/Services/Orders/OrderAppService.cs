using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Repositories.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TARetailOrder.ApiService.Services.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderHeaderAppService _orderHeaderAppService;
        private readonly IOrderDetailAppService _orderDetailAppService;
        private readonly ILogger<OrderAppService> _logger;
        private readonly IMapper _mapper;
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        public OrderAppService(IOrderHeaderAppService orderHeaderAppService,
            IOrderDetailAppService orderDetailAppService,
            ILogger<OrderAppService> logger,
            IMapper mapper,
            IOrderHeaderRepository orderHeaderRepository)
        {
            _orderHeaderAppService = orderHeaderAppService;
            _orderDetailAppService = orderDetailAppService;
            _logger = logger;
            _mapper = mapper;
            _orderHeaderRepository = orderHeaderRepository;
        }

        //Notes:
        //Create an Order → POST /orders
        //Get an Order by ID → GET /orders/{orderId} 
        //Get All Orders for a Customer → GET /orders/customer/{customerId}
        //Update Order Status → PUT /orders/{orderId}/ status

        //Business Logic: 
        //Each order contains multiple items(Product ID, Quantity, Price). 
        //Orders should have a status(Pending, Processed, Shipped). 
        //Order total amount should be automatically calculated.

        public async Task<Guid?> Create(CreateOrderDto input)
        {
            try
            {
                if(input.Header == null)
                {
                    throw new ArgumentException("Header is Empty. Unable to proceed!", nameof(input.Header));
                }

                var headerId = await _orderHeaderAppService.CreateOrEditAsync(input.Header);
                if(headerId.HasValue)
                {
                    _logger.LogInformation("Successfully inserted Header.");

                    await _orderDetailAppService.CreateRangeAsync(input.Details);
                }
                return headerId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Header. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task<GetOrderByHeaderDto> GetByOrderIdAsync(Guid Id)
        {
            try
            {
                if(Id == Guid.Empty)
                {
                    throw new ArgumentException("Order Id is Empty. Unable to proceed!", nameof(Id));
                }

                var header = await _orderHeaderAppService.GetByIdAsync(Id,Guid.Empty);

                if (header == null)
                {
                    _logger.LogInformation("No Header Record");
                    return new GetOrderByHeaderDto();
                }

                var details = await _orderDetailAppService.GetByHeaderIdAsync(Id);

                return new GetOrderByHeaderDto()
                {
                    Header = header,
                    Details = details,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve headers. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task<GetOrderByHeaderDto> GetByCustomerIdAsync(Guid Id)
        {
            try
            {
                if (Id == Guid.Empty)
                {
                    throw new ArgumentException("Customer Id is Empty. Unable to proceed!", nameof(Id));
                }

                var header = await _orderHeaderAppService.GetByIdAsync(Guid.Empty,Id);

                if (header == null)
                {
                    _logger.LogInformation("No Header Record");
                    return new GetOrderByHeaderDto();
                }

                var details = await _orderDetailAppService.GetByHeaderIdAsync(Id);

                return new GetOrderByHeaderDto()
                {
                    Header = header,
                    Details = details,
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve headers. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task UpdateStatusAsync(UpdateOrderStatusDto input)
        {
            try
            {
                var header = await _orderHeaderAppService.GetByIdAsync(input.Id, Guid.Empty);
                if(header != null)
                {
                    header.Header.Status = input.Status;
                    var Header = _mapper.Map<OrderHeader>(header.Header);
                    await _orderHeaderRepository.UpdateAsync(Header);
                    _logger.LogInformation("Successfully updated Header.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Header. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }


    }
}
