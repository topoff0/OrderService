using FluentValidation;
using OrderService.Core.Dtos;

namespace OrderService.Services.Validators.CreateDtos
{
    public class CreateOrderItemDtoValidator : AbstractValidator<CreateDto.CreateOrderItemDto>
    {
        public CreateOrderItemDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product must have a name")
                .MaximumLength(200).WithMessage("Product name must be less than 200 symbols");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Count of products must be greater than 0");
        }
    }
}