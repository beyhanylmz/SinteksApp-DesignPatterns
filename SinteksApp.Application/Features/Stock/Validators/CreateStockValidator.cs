using SinteksApp.Application.Features.Stock.Commands;

namespace SinteksApp.Application.Features.Stock.Validators;

using FluentValidation;

public class CreateStockValidator : AbstractValidator<CreateStockCommand>
{
    public CreateStockValidator()
    {
        RuleFor(x => x.BranchId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
        
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");  
        
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");
    }
}
