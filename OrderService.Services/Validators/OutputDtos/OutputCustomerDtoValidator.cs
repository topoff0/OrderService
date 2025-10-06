using FluentValidation;
using OrderService.Core.Dtos;

namespace OrderService.Services.Validators.OutputDtos
{
    public class OutputCustomerDtoValidator : AbstractValidator<OutputDto.CustomerDto>
    {
        public OutputCustomerDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Customer ID is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required")
                .MaximumLength(100).WithMessage("Customer name must be less than 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Customer email is required")
                .EmailAddress().WithMessage("Invalid email format");
        }
    }
}