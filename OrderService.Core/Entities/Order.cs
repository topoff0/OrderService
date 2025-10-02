
using OrderService.Core.Dtos.OrderDtos;
using OrderService.Core.Enums;

namespace OrderService.Core.Entities
{
    public class Order
    {
        public Order(OrderDto dto)
        {
            CustomerId = dto.Customer.Id;
            Customer = dto.Customer;
            TotalAmount = dto.TotalAmount;
            OrderItems = dto.OrderItems;

            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Created;
        }

        private Order() { }

        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;

        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; } = null!;
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}