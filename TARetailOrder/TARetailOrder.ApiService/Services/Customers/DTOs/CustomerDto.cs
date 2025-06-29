using System.ComponentModel.DataAnnotations;

namespace TARetailOrder.ApiService.Services.Customers.DTOs
{
    public class CustomerDto
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
        public string? ShippingAddress { get; set; }
        public string? BillingAddress { get; set; }
    }
}
