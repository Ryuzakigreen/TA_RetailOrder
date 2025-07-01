using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TARetailOrder.ApiService.Services.Customers.DTOs
{
    public class CreateOrEditCustomerDto
    {
        [SwaggerSchema("Leave empty for new customer, provide existing ID for updates")]
        public Guid? ID { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string LastName { get; set; }
        public string? Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Phone number must start with 09 and be 11 digits")]
        public string PhoneNo { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string ShippingAddress { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string BillingAddress { get; set; }
    }
}
