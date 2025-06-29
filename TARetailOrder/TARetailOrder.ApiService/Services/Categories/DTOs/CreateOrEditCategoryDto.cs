using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Categories.DTOs
{
    public class CreateOrEditCategoryDto
    {
        [SwaggerSchema("Leave empty for new Category, provide existing ID for updates")]
        public Guid? ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
