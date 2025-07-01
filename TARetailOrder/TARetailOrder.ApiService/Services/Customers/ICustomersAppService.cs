using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Services.Customers
{
    public interface ICustomersAppService
    {
        Task<GetAllCustomerDto> GetAllByPageAsync(FilterInputDto filter);
        Task<CustomerDto> GetByIdAsync(Guid id);
        Task CreateOrEditAsync(CreateOrEditCustomerDto input);
        Task DeleteAsync(Guid id);
    }
}