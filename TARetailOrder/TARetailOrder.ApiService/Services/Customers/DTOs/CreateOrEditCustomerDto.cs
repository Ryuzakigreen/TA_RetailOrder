using System.ComponentModel.DataAnnotations;

namespace TARetailOrder.ApiService.Services.Customers.DTOs
{
    public class CreateOrEditCustomerDto
    {
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        public string LastName { get; set; }
        public string? Email { get; set; }
        [Required]
        [StringLength(11)]
        public string PhoneNo { get; set; }
        [Required]
        [StringLength(500)]
        public string ShippingAddress { get; set; }
        [Required]
        [StringLength(500)]
        public string BillingAddress { get; set; }
    }
}
