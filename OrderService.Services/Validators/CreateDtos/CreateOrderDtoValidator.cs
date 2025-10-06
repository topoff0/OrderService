using FluentValidation;
using OrderService.Core.Dtos;
using OrderService.Services.Validators.OutputDtos;

namespace OrderService.Services.Validators.CreateDtos
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateDto.CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.CustomerDto)
                .NotNull().WithMessage("Customer information is required")
                    .SetValidator(new OutputCustomerDtoValidator());


            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt cannot be in the future");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid order status");

            RuleForEach(x => x.OrderItemDtos)
                .SetValidator(new OutputOrderItemDtoValidator());

            RuleFor(x => x.OrderItemDtos)
                .NotEmpty().WithMessage("Order must contain at least one item");
        }
    }
}