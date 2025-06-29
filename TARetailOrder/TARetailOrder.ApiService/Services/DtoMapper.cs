using AutoMapper;
using TARetailOrder.ApiService.Services.Customers.DTOs;
using TARetailOrder.ApiService.DataContext.Models;
namespace TARetailOrder.ApiService.Services
{
    public class DtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateOrEditCustomerDto, Customer>().ReverseMap();
            configuration.CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
