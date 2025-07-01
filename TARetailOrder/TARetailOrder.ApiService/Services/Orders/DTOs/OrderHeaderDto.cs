using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class OrderHeaderDto
    {
        public Guid ID { get; set; }
        public string RefNo { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
    }
}
