
namespace OrderService.Core.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = default!;

        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;
    }
}