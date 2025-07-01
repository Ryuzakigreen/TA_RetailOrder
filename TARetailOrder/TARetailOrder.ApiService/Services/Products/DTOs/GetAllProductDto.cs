using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Services.Products.DTOs
{
    public class GetAllProductDto
    {
        public SummaryResult SummaryResult { get; set; }
        public List<ViewProductDto> ProductList { get; set; }
    }
    public class SummaryResult
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
