using FluentValidation;
using OrderService.Core.Dtos;

namespace OrderService.Services.Validators.OutputDtos
{
    public class OutputOrderItemDtoValidator : AbstractValidator<OutputDto.OrderItemDto>
    {
        public OutputOrderItemDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Order item ID is required");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(200).WithMessage("Product name must be less than 200 symbols");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}