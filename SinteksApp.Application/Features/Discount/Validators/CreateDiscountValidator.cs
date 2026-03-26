using FluentValidation;
using SinteksApp.Application.Features.Discount.Commands;

namespace SinteksApp.Application.Features.Discount.Validators;

public class CreateDiscountValidator : AbstractValidator<CreateDiscountCommand>
{
    public CreateDiscountValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Discount name cannot be empty")
            .MaximumLength(200)
            .WithMessage("Discount name cannot exceed 200 characters");

        RuleFor(x => x.DiscountPercent)
            .GreaterThan(0)
            .WithMessage("DiscountPercent must be greater than 0")
            .LessThanOrEqualTo(100)
            .WithMessage("DiscountPercent must be less than or equal to 100");

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("StartDate cannot be after EndDate");

        RuleFor(x => x.Priority)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Priority cannot be negative");

        RuleFor(x => x)
            .Must(HasAtLeastOneTarget)
            .WithMessage("At least one discount target is required. BranchIds, ProductIds, CategoryIds, or BrandIds must contain at least one value.");

        RuleFor(x => x)
            .Must(NotContainConflictingProducts)
            .WithMessage("Excluded products cannot also exist in ProductIds.");
    }

    private static bool HasAtLeastOneTarget(CreateDiscountCommand command)
    {
        return Normalize(command.BranchIds).Any()
               || Normalize(command.ProductIds).Any()
               || Normalize(command.CategoryIds).Any()
               || Normalize(command.BrandIds).Any();
    }

    private static bool NotContainConflictingProducts(CreateDiscountCommand command)
    {
        var productIds = Normalize(command.ProductIds);
        var excludedProductIds = Normalize(command.ExcludedProductIds);

        return !productIds.Intersect(excludedProductIds).Any();
    }

    private static List<int> Normalize(IEnumerable<int>? ids)
    {
        return (ids ?? Enumerable.Empty<int>())
            .Where(x => x > 0)
            .Distinct()
            .ToList();
    }
}