using AutoMapper;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Repositories.Orders;
using TARetailOrder.ApiService.Services.Orders;
using TARetailOrder.ApiService.Services.Orders.DTOs;

namespace TARetailOrder.ApiService.Services.Orders
{
    public class OrderHeaderAppService : IOrderHeaderAppService
    {
        private readonly IOrderHeaderRepository _orderHeaderRepository;
        private readonly ILogger<OrderHeaderAppService> _logger;
        private readonly IMapper _mapper;
        public OrderHeaderAppService(IOrderHeaderRepository orderHeaderRepository,
            ILogger<OrderHeaderAppService> logger,
            IMapper mapper)
        {
            _orderHeaderRepository = orderHeaderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetAllOrderHeaderDto> GetAllByPageAsync(FilterInputDto filter)
        {
            try
            {
                if (filter.page == 0)
                {
                    throw new ArgumentException("Page No. must greater than 0(zero)!", nameof(filter.page));
                }
                if (filter.size == 0)
                {
                    throw new ArgumentException("Page size must greater than 0(zero)!", nameof(filter.size));
                }

                var headers = await _orderHeaderRepository.GetAllByPageAsync(filter);

                if (headers.TotalCount == 0)
                {
                    _logger.LogInformation("No Header Record");
                    return new GetAllOrderHeaderDto()
                    {
                        SummaryResult = new SummaryResult
                        {
                            Page = filter.page,
                            TotalCount = 0
                        },
                        HeaderList = new List<ViewOrderHeaderDto>()
                    };
                }

                _logger.LogInformation("Successfully retrieved {0} headers", headers.TotalCount);
                return new GetAllOrderHeaderDto
                {
                    SummaryResult = new SummaryResult
                    {
                        Page = filter.page,
                        TotalCount = headers.TotalCount
                    },
                    HeaderList = headers.Items.Select(o => new ViewOrderHeaderDto
                    {
                        CustomerName = string.Format("{0},{1}", o.CustomerFk?.LastName?.ToString(), o.CustomerFk?.FirstName?.ToString()),
                        Header = new OrderHeaderDto
                        {
                            ID = o.ID,
                            RefNo = o.RefNo,
                            CustomerId = o.CustomerId,
                            CreationTime = o.CreationTime,
                            Status = o.Status
                        }
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve headers. Error: {ErrorMessage}", ex.Message);
                throw;
            }

        }

        public async Task<ViewOrderHeaderDto> GetByIdAsync(Guid? headerId, Guid? customerId)
        {
            try
            {
                if(headerId != Guid.Empty)
                {
                    var header = await _orderHeaderRepository.GetByIdAsync((Guid)headerId);
                    if (header != null)
                    {
                        _logger.LogInformation("Successfully retrieved Header.");

                        return new ViewOrderHeaderDto()
                        {
                            CustomerName = string.Format("{0},{1}", header.CustomerFk?.LastName?.ToString(), header.CustomerFk?.FirstName?.ToString()),
                            Header = new OrderHeaderDto
                            {
                                ID = header.ID,
                                RefNo = header.RefNo,
                                CustomerId = header.CustomerId,
                                CreationTime = header.CreationTime,
                                Status = header.Status
                            }
                        };
                    }
                    else
                    {
                        _logger.LogInformation("No record found.");
                        return new ViewOrderHeaderDto();
                    }
                }
                else if(customerId != Guid.Empty)
                {
                    var header = await _orderHeaderRepository.GetAllHeaderAsync();
                    if (header != null)
                    {

                        var qry = header.FirstOrDefault(x => x.Key == customerId).Value;
                        if(qry != null)
                        {
                            return new ViewOrderHeaderDto()
                            {
                                CustomerName = string.Format("{0},{1}", qry.CustomerFk?.LastName?.ToString(), qry.CustomerFk?.FirstName?.ToString()),
                                Header = new OrderHeaderDto
                                {
                                    ID = qry.ID,
                                    RefNo = qry.RefNo,
                                    CustomerId = qry.CustomerId,
                                    CreationTime = qry.CreationTime,
                                    Status = qry.Status
                                }
                            };
                        }
                    }
                    else
                    {
                        _logger.LogInformation("No record found.");
                        return new ViewOrderHeaderDto();
                    }
                }

                return new ViewOrderHeaderDto();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve Header. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task<Guid?> CreateOrEditAsync(CreateOrEditOrderHeaderDto input)
        {
            if (input.ID == Guid.Empty)
            {
                return await Create(input);
            }
            else
            {
                return await Update(input);
            }
        }

        private async Task<Guid?> Create(CreateOrEditOrderHeaderDto input)
        {
            try
            {
                var Header = _mapper.Map<OrderHeader>(input);
                _logger.LogInformation("Successfully inserted Header.");
                return await _orderHeaderRepository.InsertAsync(Header);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Header. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
        private async Task<Guid?> Update(CreateOrEditOrderHeaderDto input)
        {
            try
            {
                var Header = _mapper.Map<OrderHeader>(input);
                await _orderHeaderRepository.UpdateAsync(Header);
                _logger.LogInformation("Successfully updated Header.");
                return input.ID;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Header. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

    }
}
