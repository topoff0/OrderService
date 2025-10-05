using OrderService.Core.Enums;

namespace OrderService.Core.Dtos
{
    public class CreateDtos
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
            OutputDtos.CustomerDto CustomerDto,
            DateTime CreatedAt,
            OrderStatus Status,
            List<OutputDtos.OrderItemDto> OrderItemDtos
        );
    }
}