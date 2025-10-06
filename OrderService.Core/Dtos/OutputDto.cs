using OrderService.Core.Enums;

namespace OrderService.Core.Dtos
{
    public class OutputDto
    {
        public record CustomerDto(Guid Id, string Name, string Email);

        public record OrderItemDto
        (Guid Id,
        string ProductName,
        decimal UnitPrice,
        int Quantity
        );

        public record OrderDto
        (
            Guid Id,
            CustomerDto CustomerDto,
            DateTime CreatedAt,
            DateTime? ProcessedAt,
            OrderStatus Status,
            decimal TotalAmount,
            List<OrderItemDto> OrderItemDtos
        );
    }
}