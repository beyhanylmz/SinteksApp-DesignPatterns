using SinteksApp.Application.Features.BranchProductAssortment.Commands;

namespace SinteksApp.Application.Features.BranchProductAssortment.Validators;

using FluentValidation;

public class UpdateBranchProductAssortmentValidator : AbstractValidator<UpdateBranchProductAssortmentCommand>
{
    public UpdateBranchProductAssortmentValidator()
    {
        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
        
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
    }
}