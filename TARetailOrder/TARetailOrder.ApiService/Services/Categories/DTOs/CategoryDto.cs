using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Categories.DTOs
{
    public class CategoryDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
