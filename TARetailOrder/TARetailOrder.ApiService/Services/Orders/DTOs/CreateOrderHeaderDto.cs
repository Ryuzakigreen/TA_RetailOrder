using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class CreateOrderHeaderDto
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string RefNo { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
    }
}
