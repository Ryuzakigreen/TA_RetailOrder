using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Services.Categories.DTOs
{
    public class GetAllCategoryDto
    {
        public SummaryResult SummaryResult { get; set; }
        public List<CategoryDto> CategoryList { get; set; }
    }
    public class SummaryResult
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
