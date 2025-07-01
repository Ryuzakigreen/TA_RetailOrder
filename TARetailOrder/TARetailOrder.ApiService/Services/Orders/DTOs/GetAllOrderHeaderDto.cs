using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class GetAllOrderHeaderDto
    {
        public SummaryResult SummaryResult { get; set; }
        public List<ViewOrderHeaderDto> HeaderList { get; set; }
    }
    public class SummaryResult
    {
        public int Page { get; set; }
        public int TotalCount { get; set; }
    }
}
