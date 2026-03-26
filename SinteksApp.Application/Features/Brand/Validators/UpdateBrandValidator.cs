using FluentValidation;
using SinteksApp.Application.Features.Brand.Commands;

namespace SinteksApp.Application.Features.Brand.Validators;

public class UpdateBrandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Brand name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Brand name cannot exceed 100 characters");

        RuleFor(x => x.SubCompanyId)
            .NotEmpty()
            .WithMessage("SubCompanyId cannot be empty");
    }
}
