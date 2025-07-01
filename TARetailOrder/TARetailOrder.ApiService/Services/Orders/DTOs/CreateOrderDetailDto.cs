using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class CreateOrderDetailDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Range(1, 9999, ErrorMessage = "Quantity must be between 1 and 9999")]
        public int Qty { get; set; }
    }
}
