using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Repositories.Customers;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Services.Customers
{
    public class CustomersAppService : ICustomersAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomersAppService> _logger;
        private readonly IMapper _mapper;
        public CustomersAppService(
            ICustomerRepository customerRepository, 
            ILogger<CustomersAppService> logger,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<GetAllCustomerDto> GetAllByPageAsync(FilterInputDto filter)
        {
            try
            {
                if(filter.page == 0)
                {
                    throw new ArgumentException("Page No. must greater than 0(zero)!", nameof(filter.page));
                }
                if (filter.size == 0)
                {
                    throw new ArgumentException("Page size must greater than 0(zero)!", nameof(filter.size));
                }

                var customers = await _customerRepository.GetAllByPageAsync(filter);

                if (customers.TotalCount == 0)
                {
                    _logger.LogInformation("No Customer Record");
                    return new GetAllCustomerDto()
                    {
                        SummaryResult = new SummaryResult
                        {
                            Page = filter.page,
                            TotalCount = 0
                        },
                        CustomerList = new List<CustomerDto>()
                    };
                }

                _logger.LogInformation("Successfully retrieved {0} customers", customers.TotalCount);
                return new GetAllCustomerDto
                {
                    SummaryResult = new SummaryResult
                    {
                        Page = filter.page,
                        TotalCount = customers.TotalCount
                    },
                    CustomerList = customers.Items.Select(o => new CustomerDto
                    {
                        ID = o.ID.ToString(),
                        LastName = o.LastName,
                        FirstName = o.FirstName,
                        Email = o.Email,
                        PhoneNo = o.PhoneNo,
                        ShippingAddress = o.ShippingAddress,
                        BillingAddress = o.BillingAddress
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve customers. Error: {ErrorMessage}", ex.Message);
                throw;
            }
            
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Customer ID cannot be empty.", nameof(id));
            }
            try
            {
                var customer = await _customerRepository.GetByIdAsync(id);
                if(customer!= null)
                {
                    _logger.LogInformation("Successfully retrieved customer.");

                    return new CustomerDto()
                    {
                        ID = customer.ID.ToString(),
                        LastName = customer.LastName,
                        FirstName = customer.FirstName,
                        Email = customer.Email,
                        PhoneNo = customer.PhoneNo,
                        ShippingAddress = customer.ShippingAddress,
                        BillingAddress = customer.BillingAddress
                    };
                }
                else
                {
                    _logger.LogInformation("No record found.");
                    return new CustomerDto();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve customer. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Customer ID cannot be empty.", nameof(id));
            }
            try
            {
                await _customerRepository.DeleteByIdAsync(id);
                _logger.LogInformation("Successfully deleted customer.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete customer. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

        public async Task CreateOrEditAsync(CreateOrEditCustomerDto input)
        {
            if(input.ID == Guid.Empty)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        private async Task Create(CreateOrEditCustomerDto input)
        {
            try
            {
                var customer = _mapper.Map<Customer>(input);
                await _customerRepository.InsertAsync(customer);
                _logger.LogInformation("Successfully inserted customer.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete customer. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }
        private async Task Update(CreateOrEditCustomerDto input)
        {
            try
            {
                var customer = _mapper.Map<Customer>(input);
                await _customerRepository.UpdateAsync(customer);
                _logger.LogInformation("Successfully updated customer.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete customer. Error: {ErrorMessage}", ex.Message);
                throw;
            }
        }

    }
}
