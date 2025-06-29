using AutoMapper;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Services.Categories.DTOs;
using TARetailOrder.ApiService.Services.Customers.DTOs;
namespace TARetailOrder.ApiService.Services
{
    public class DtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateOrEditCustomerDto, Customer>().ReverseMap();
            configuration.CreateMap<CustomerDto, Customer>().ReverseMap();

            configuration.CreateMap<CreateOrEditCategoryDto, Category>().ReverseMap();
            configuration.CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
