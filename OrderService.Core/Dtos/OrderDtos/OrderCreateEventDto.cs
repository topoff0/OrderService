namespace OrderService.Core.Dtos.OrderDtos
{
    public class OrderCreateEventDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalAmount { get; set; }
    }
}