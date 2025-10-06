
using System.Diagnostics;
using OrderService.Core.Dtos;
using OrderService.Core.Enums;

namespace OrderService.Core.Entities
{
    public class Order
    {
        public Order(CreateDto.CreateOrderDto dto)
        {
            CustomerId = dto.CustomerDto.Id;
            Customer = new Customer
            (
                new CreateDto.CreateCustomerDto
                (
                    dto.CustomerDto.Name, dto.CustomerDto.Email
                )
            );
            CreatedAt = DateTime.UtcNow;
            Status = OrderStatus.Created;
            OrderItems = dto.OrderItemDtos.Select(oid => new OrderItem
            (
                new CreateDto.CreateOrderItemDto
                (
                    oid.ProductName, oid.UnitPrice, oid.Quantity
                )
            )).ToList();

            TotalAmount = OrderItems.Sum(oi => oi.TotalPrice);
        }

        private Order() { }

        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; } = default!;

        public DateTime CreatedAt { get; private set; }
        public DateTime? ProcessedAt { get; private set; } = null!;
        public OrderStatus Status { get; private set; }
        public List<OrderItem> OrderItems { get; private set; } = [];
        public decimal TotalAmount { get; private set; }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
            TotalAmount += item.TotalPrice;
        }

        public void MarkProcessing()
        {
            Status = OrderStatus.Processed;
        }

        public void MarkProcessed()
        {
            Status = OrderStatus.Processed;
            ProcessedAt = DateTime.UtcNow;
        }

        public void RemoveItem(OrderItem item)
        {
            if (OrderItems.Remove(item))
            {
                TotalAmount -= item.TotalPrice;
            }
        }
    }
}