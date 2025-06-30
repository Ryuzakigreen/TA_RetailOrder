namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class CreateOrderDto
    {
        public CreateOrEditOrderHeaderDto Header { get; set; }
        public List<CreateOrEditOrderDetailDto> Details { get; set; }
    }
}
