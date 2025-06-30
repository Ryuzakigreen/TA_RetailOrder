using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class OrderHeaderDto
    {
        public string ID { get; set; }
        public string RefNo { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
