using SinteksApp.Application.Features.Product.Commands;

namespace SinteksApp.Application.Features.Product.Validators;

using FluentValidation;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name cannot be empty")
            .MaximumLength(100)
            .WithMessage("Product name cannot exceed 100 characters");
   
        RuleFor(x => x.PurchasePrice)
            .NotEmpty()
            .WithMessage("PurchasePrice cannot be empty"); 
        
        RuleFor(x => x.BaseSalePrice)
            .NotEmpty()
            .WithMessage("PurchasePrice cannot be empty");  
        RuleFor(x => x.Color)
            .NotEmpty()
            .WithMessage("PurchasePrice cannot be empty");  
        RuleFor(x => x.Size)
            .NotEmpty()
            .WithMessage("PurchasePrice cannot be empty");  
    
        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");   
        RuleFor(x => x.ProductCategoryId)
            .GreaterThan(0)
            .WithMessage("BrandId must be greater than 0");
    }
}
