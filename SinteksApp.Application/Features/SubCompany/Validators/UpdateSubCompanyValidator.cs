using FluentValidation;
using SinteksApp.Application.Features.SubCompany.Commands;

namespace SinteksApp.Application.Features.SubCompany.Validators;

public class UpdateSubCompanyValidator : AbstractValidator<UpdateSubCompanyCommand>
{
    public UpdateSubCompanyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("SubCompany name cannot be empty")
            .MaximumLength(100)
            .WithMessage("SubCompany name cannot exceed 100 characters");
    }
}
