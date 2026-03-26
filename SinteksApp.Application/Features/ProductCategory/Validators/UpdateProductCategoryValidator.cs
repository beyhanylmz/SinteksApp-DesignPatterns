using SinteksApp.Application.Features.ProductCategory.Commands;

namespace SinteksApp.Application.Features.ProductCategory.Validators;

using FluentValidation;

public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("ProductCategory name cannot be empty")
            .MaximumLength(100)
            .WithMessage("ProductCategory name cannot exceed 100 characters");
    }
}