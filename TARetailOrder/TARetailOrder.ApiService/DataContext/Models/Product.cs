using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.DataContext.Models
{
    [Table("Products")]
    public class Product
    {
        public Guid ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        public Guid? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category CategoryFk { get; set; }

        public Status Status { get; set; }

        //Auditlogs
        public DateTime CreationTime { get; set; }
        public int CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? LastModifierUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
        public int DeleterUserId { get; set; }
    }
}
