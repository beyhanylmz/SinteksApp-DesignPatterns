using SinteksApp.Application.Features.Stock.Commands;

namespace SinteksApp.Application.Features.Stock.Validators;

using FluentValidation;

public class UpdateStockValidator : AbstractValidator<UpdateStockCommand>
{
    public UpdateStockValidator()
    {
        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
        
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
    }
}