using OrderService.Core.Enums;

namespace OrderService.Core.Dtos
{
    public class CreateDto
    {
        public record CreateCustomerDto(string Name, string Email);

        public record CreateOrderItemDto
        (
            string ProductName,
            decimal UnitPrice,
            int Quantity
        );

        public record CreateOrderDto
        (
            OutputDto.CustomerDto CustomerDto,
            DateTime CreatedAt,
            OrderStatus Status,
            List<OutputDto.OrderItemDto> OrderItemDtos
        );
    }
}