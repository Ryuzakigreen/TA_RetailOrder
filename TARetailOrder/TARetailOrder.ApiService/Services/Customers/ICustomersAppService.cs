using TARetailOrder.ApiService.Services.Customers.DTOs;

namespace TARetailOrder.ApiService.Services.Customer
{
    public interface ICustomersAppService
    {
        Task<GetAllCustomerDto> GetAllAsync(GetCustomerFilterInputDto filter);
    }
}