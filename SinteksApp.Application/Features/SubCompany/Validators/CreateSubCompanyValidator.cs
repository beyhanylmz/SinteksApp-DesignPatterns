using FluentValidation;
using SinteksApp.Application.Features.SubCompany.Commands;

namespace SinteksApp.Application.Features.SubCompany.Validators;

public class CreateSubCompanyValidator : AbstractValidator<CreateSubCompanyCommand>
{
    public CreateSubCompanyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("SubCompany name cannot be empty")
            .MaximumLength(100)
            .WithMessage("SubCompany name cannot exceed 100 characters");
    }
}
