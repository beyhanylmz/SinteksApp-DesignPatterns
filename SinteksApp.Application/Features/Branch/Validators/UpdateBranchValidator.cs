using SinteksApp.Application.Features.Branch.Commands;

namespace SinteksApp.Application.Features.Branch.Validators;

using FluentValidation;

public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Branch name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Branch name cannot exceed 100 characters");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address cannot be empty")
            .MaximumLength(200)
            .WithMessage("Address cannot exceed 200 characters");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
    }
}
