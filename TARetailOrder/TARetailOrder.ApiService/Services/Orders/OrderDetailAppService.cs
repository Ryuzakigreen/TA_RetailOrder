using AutoMapper;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Repositories.Orders;
using TARetailOrder.ApiService.Repositories.Products;
using TARetailOrder.ApiService.Services.Orders.DTOs;
using TARetailOrder.ApiService.Services.Products;

namespace TARetailOrder.ApiService.Services.Orders
{
    public class OrderDetailAppService : IOrderDetailAppService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ILogger<OrderDetailAppService> _logger;
        private readonly IMapper _mapper;
        public OrderDetailAppService(IOrderDetailRepository orderDetailRepository,
            ILogger<OrderDetailAppService> logger,
            IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetAllOrderDetailDto> GetAllAsync(FilterInputDto filter)
        {
            try
            {
                var details = await _orderDetailRepository.GetAllByPageAsync(filter);

                if (details.TotalCount == 0)
                {
                    _logger.LogInformation("No detail Record");
                    return new GetAllOrderDetailDto()
                    {
                        SummaryResult = new SummaryResult
                        {
                            Page = filter.page,
                            TotalCount = 0
                        },
                        DetailList = new List<ViewOrderDetailDto>()
                    };
                }

                _logger.LogInformation("Successfully retrieved {0} details", details.TotalCount);
                return new GetAllOrderDetailDto
                {
                    SummaryResult = new SummaryResult
                    {
                        Page = filter.page,
                        TotalCount = details.TotalCount
                    },
                    DetailList = details.Items.Select(o => new ViewOrderDetailDto
                    {
                        Detail = new OrderDetailDto
                        {
                            ID = o.ID,
                            OrderHeaderId = o.OrderHeaderId,
                            ProductId = o.ProductId,
                            Qty = o.Qty,
                            TotalAmt = o.TotalAmt,
                            CreationTime = o.CreationTime,
                        }
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve details. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task<ViewOrderDetailDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("detail ID cannot be empty.", nameof(id));
            }
            try
            {
                var detail = await _orderDetailRepository.GetByIdAsync(id);
                if (detail != null)
                {
                    _logger.LogInformation("Successfully retrieved detail.");

                    return new ViewOrderDetailDto()
                    {
                        ProductName = detail.ProductFk?.Name?.ToString(),
                        Detail = new OrderDetailDto
                        {
                            ID = detail.ID,
                            OrderHeaderId= detail.OrderHeaderId,
                            ProductId = detail.ProductId,
                            Qty= detail.Qty,
                            TotalAmt= detail.TotalAmt,
                            CreationTime = detail.CreationTime,
                        }
                    };
                }
                else
                {
                    _logger.LogInformation("No record found.");
                    return new ViewOrderDetailDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve detail. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task<List<ViewOrderDetailDto>> GetByHeaderIdAsync(Guid headerId)
        {
            if (headerId == Guid.Empty)
            {
                throw new ArgumentException("Header ID cannot be empty.", nameof(headerId));
            }
            try
            {
                var details = await _orderDetailRepository.GetAllAsync();
                if (details != null)
                {
                    _logger.LogInformation("Successfully retrieved detail.");

                    return details.Where(x => x.OrderHeaderId == headerId)
                        .Select(o => new ViewOrderDetailDto()
                        {
                            ProductName = o.ProductFk?.Name?.ToString(),
                            Detail = new OrderDetailDto
                            {
                                ID = o.ID,
                                OrderHeaderId = o.OrderHeaderId,
                                ProductId = o.ProductId,
                                Qty = o.Qty,
                                TotalAmt = o.TotalAmt,
                                CreationTime = o.CreationTime,
                            }

                        }).ToList();
                }
                else
                {
                    _logger.LogInformation("No record found.");
                    return new List<ViewOrderDetailDto>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve detail. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task CreateOrEditAsync(CreateOrEditOrderDetailDto input)
        {
            if (input.ID == Guid.Empty)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        private async Task Create(CreateOrEditOrderDetailDto input)
        {
            try
            {
                var detail = _mapper.Map<OrderDetail>(input);
                await _orderDetailRepository.InsertAsync(detail);
                _logger.LogInformation("Successfully inserted detail.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create detail. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
        private async Task Update(CreateOrEditOrderDetailDto input)
        {
            try
            {
                var detail = _mapper.Map<OrderDetail>(input);
                await _orderDetailRepository.UpdateAsync(detail);
                _logger.LogInformation("Successfully updated detail.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update detail. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task CreateRangeAsync(List<CreateOrEditOrderDetailDto> input)
        {
            try
            {
                var details = _mapper.Map<List<OrderDetail>>(input);
                await _orderDetailRepository.InsertRangeAsync(details);
                _logger.LogInformation("Successfully inserted detail.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create detail. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
    }
}
