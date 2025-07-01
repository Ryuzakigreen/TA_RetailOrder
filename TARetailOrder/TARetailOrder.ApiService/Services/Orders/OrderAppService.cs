using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Repositories.Orders;
using TARetailOrder.ApiService.Repositories.Products;
using TARetailOrder.ApiService.Services.Orders.DTOs;
using TARetailOrder.ApiService.Services.Products;
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
        private readonly IProductsAppService _productsAppService;
        private readonly DBDataContext _db;
        private readonly IProductRepository _productRepository;
        public OrderAppService(IOrderHeaderAppService orderHeaderAppService,
            IOrderDetailAppService orderDetailAppService,
            ILogger<OrderAppService> logger,
            IMapper mapper,
            IOrderHeaderRepository orderHeaderRepository,
            IProductsAppService productsAppService,
            DBDataContext db,
            IProductRepository productRepository)
        {
            _orderHeaderAppService = orderHeaderAppService;
            _orderDetailAppService = orderDetailAppService;
            _logger = logger;
            _mapper = mapper;
            _orderHeaderRepository = orderHeaderRepository;
            _productsAppService = productsAppService;
            _db = db;
            _productRepository = productRepository;
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
                if(input.Header.CustomerId == Guid.Empty && !input.Header.RefNo.Any())
                {
                    throw new ArgumentException("Header is Empty. Unable to proceed!", nameof(input.Header));
                }

                var headerId = await _orderHeaderAppService.CreateOrEditAsync(new CreateOrEditOrderHeaderDto()
                                {
                                    RefNo = input.Header.RefNo,
                                    CustomerId = input.Header.CustomerId,
                                    Status = Enums.OrderStatus.Pending
                                });
                if(headerId.HasValue && input.Details.Count() > 0)
                {
                    var products = await _productRepository.GetAllProductAsync();
                    var detailList = new List<CreateOrEditOrderDetailDto>();
                    if (products == null)
                    {
                        _logger.LogInformation("Failed to create details. No Product items | Order ID: {0}", headerId);
                        return headerId;
                    }
                    foreach (var o in input.Details)
                    {
                        var product = products.FirstOrDefault(x => x.Key == o.ProductId).Value;
                        if (product == null)
                        {
                            continue;
                        }
                        var item = new CreateOrEditOrderDetailDto()
                        {
                            OrderHeaderId = (Guid)headerId,
                            ProductId = o.ProductId,
                            Qty = o.Qty,
                            TotalAmt = product.UnitPrice * o.Qty,
                        };
                        detailList.Add(item);
                    }
                    await _orderDetailAppService.CreateRangeAsync(detailList);
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

                if (header.Header == null)
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

                if (header.Header == null)
                {
                    _logger.LogInformation("No Header Record");
                    return new GetOrderByHeaderDto();
                }
                decimal gTotal = 0;
                var details = await _orderDetailAppService.GetByHeaderIdAsync(header.Header.ID);
                if(details.Count() > 0)
                {
                    //Compute sum total of all order details
                    gTotal = details.Sum(e => e.Detail.TotalAmt);
                }
                header.GrandTotal = gTotal;

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

        public async Task<string> UpdateStatusAsync(UpdateOrderStatusDto input)
        {
            try
            {
                return await _orderHeaderRepository.UpdateAsync(new OrderHeader() { ID = input.Id, Status = input.Status });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Header. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }


    }
}
