using System.ComponentModel.DataAnnotations;
using TARetailOrder.ApiService.Services.Categories.DTOs;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class GetAllOrderDetailDto
    {
        public SummaryResult SummaryResult { get; set; }
        public List<ViewOrderDetailDto> DetailList { get; set; }
    }
}
