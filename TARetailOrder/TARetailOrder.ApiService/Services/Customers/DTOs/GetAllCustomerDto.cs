using System.ComponentModel.DataAnnotations;

namespace TARetailOrder.ApiService.Services.Customers.DTOs
{
    public class GetAllCustomerDto
    {
        public SummaryResult SummaryResult { get; set; }
        public List<CustomerDto> CustomerList { get; set; }
    }
    public class SummaryResult
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
