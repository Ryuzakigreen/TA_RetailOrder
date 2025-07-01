using TARetailOrder.ApiService.Enums;

namespace TARetailOrder.ApiService.Services.Orders.DTOs
{
    public class UpdateOrderStatusDto
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
