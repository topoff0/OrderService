
using OrderService.Core.Dtos;

namespace OrderService.Core.Entities
{
    public class OrderItem
    {

        public OrderItem(CreateDto.CreateOrderItemDto dto)
        {
            ProductName = dto.ProductName;
            UnitPrice = dto.UnitPrice;
            Quantity = dto.Quantity;
        }

        private OrderItem() { }

        public Guid Id { get; private set; }

        public Guid OrderId { get; private set; }
        public Order Order { get; private set; } = default!;

        public string ProductName { get; private set; } = string.Empty;
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public decimal TotalPrice => Quantity * UnitPrice;
    }
}