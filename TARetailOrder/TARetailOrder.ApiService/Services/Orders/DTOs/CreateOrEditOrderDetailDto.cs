using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.DataContext.Models;
using TARetailOrder.ApiService.DataContext.Models.Orders;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class CreateOrEditOrderDetailDto
    {
        [SwaggerSchema("Leave empty for new Order Detail, provide existing ID for updates")]
        public Guid ID { get; set; }
        [Required]
        public Guid OrderHeaderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmt { get; set; }
    }
}
