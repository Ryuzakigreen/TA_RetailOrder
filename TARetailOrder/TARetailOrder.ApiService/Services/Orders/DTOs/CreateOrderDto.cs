namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class CreateOrderDto
    {
        public CreateOrderHeaderDto Header { get; set; }
        public List<CreateOrderDetailDto> Details { get; set; }
    }
}
