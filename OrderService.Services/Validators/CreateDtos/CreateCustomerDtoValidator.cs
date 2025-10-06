using FluentValidation;
using OrderService.Core.Dtos;

namespace OrderService.Services.Validators.CreateDtos
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateDto.CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required")
                .MaximumLength(100).WithMessage("Name must be less than 100 symbols");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Invalid email format");
        }
    }
}