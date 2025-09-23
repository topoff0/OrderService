
namespace OrderService.Core.Dtos.Order
{
    public record CreateOrderDto(Guid CustomerId, decimal TotalAmount);
}