using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using TARetailOrder.ApiService.Repositories.Customers;
using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Services.Customer
{
    public class CustomersAppService : ICustomersAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomersAppService> _logger;
        public CustomersAppService(
            ICustomerRepository customerRepository, 
            ILogger<CustomersAppService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<GetAllCustomerDto> GetAllAsync(GetCustomerFilterInputDto filter)
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync(filter);

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
                        CustomerList = new List<CustomerList>()
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
                    CustomerList = customers.Items.Select(o => new CustomerList
                    {
                        ID = o.ID.ToString(),
                        Fullname = string.Format("{0}, {1}", o.LastName, o.FirstName),
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


    }
}
