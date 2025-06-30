using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Products.DTOs
{
    public class ProductDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public string SKU { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
