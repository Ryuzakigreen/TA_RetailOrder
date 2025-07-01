using System.ComponentModel.DataAnnotations.Schema;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class ViewOrderHeaderDto
    {
        public OrderHeaderDto Header { get; set; }
        public string? CustomerName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GrandTotal { get; set; }
    }
}
