namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class GetOrderByHeaderDto
    {
        public ViewOrderHeaderDto Header { get; set; }
        public List<ViewOrderDetailDto> Details { get; set; }
    }
}
