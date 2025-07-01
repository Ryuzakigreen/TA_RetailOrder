using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.DataContext.Models.Orders
{
    [Table("OrderHeaders")]
    public class OrderHeader
    {
        public Guid ID { get; set; }
        [Required]
        [StringLength(20)]
        public string RefNo { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer CustomerFk { get; set; }

        public OrderStatus Status { get; set; }
        //Auditlogs
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
    }
}
