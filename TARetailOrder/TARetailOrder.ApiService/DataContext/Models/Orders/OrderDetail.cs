using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.DataContext.Models.Orders
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        public Guid ID { get; set; }
        [Required]
        public Guid OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        public OrderHeader OrderHeaderFk { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product ProductFk { get; set; }

        public int Qty { get; set; }
        public decimal TotalAmt { get; set; }


        //Auditlogs
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
    }
}
