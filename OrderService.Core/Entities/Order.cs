
using OrderService.Core.Enums;

namespace OrderService.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;

        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}