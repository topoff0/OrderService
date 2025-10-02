using OrderService.Core.Entities;

namespace OrderService.Core.Dtos.OrderDtos
{
    public record OrderDto(Customer Customer, decimal TotalAmount, List<OrderItem> OrderItems);
}