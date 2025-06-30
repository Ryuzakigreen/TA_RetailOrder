using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Products.DTOs
{
    public class CreateOrEditProductDto
    {
        [SwaggerSchema("Leave empty for new Product, provide existing ID for updates")]
        public Guid? ID { get; set; }
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
        public Status Status { get; set; }
    }
}
