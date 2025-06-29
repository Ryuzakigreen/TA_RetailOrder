using System.ComponentModel.DataAnnotations;

namespace TARetailOrder.ApiService.Services.Customers.DTOs
{
    public class GetAllCustomerDto
    {
        public SummaryResult SummaryResult { get; set; }
        public List<CustomerList> CustomerList { get; set; }
    }
    public class SummaryResult
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
    public class CustomerList
    {
        public string ID { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? ShippingAddress { get; set; }
        public string? BillingAddress { get; set; }
    }
}
