using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public class DiscountEngine(IEnumerable<IDiscountStrategy> matchers) : IDiscountEngine
{
    private bool IsApplicable(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query)
    {
        // 1. Temel Şartlar (Specification)
        if (!discount.IsActive) return false;
        if (!new DateRangeSpecification().IsSatisfiedBy(discount, query)) return false;
        if (!new BranchSpecification().IsSatisfiedBy(discount, query)) return false;

        // 2. (Chain)
        if (discount.ExcludedProducts.Any(x => x.ProductId == query.ProductId)) return false;

        // 3. (Strategy)
        // Hiç hedef yoksa (Global) veya matcherlardan biri onay veriyorsa true
        var hasAnyTarget = discount.Products.Any() || discount.Categories.Any() || discount.Brands.Any();
        
        if (!hasAnyTarget) return true;

        return matchers.Any(m => m.IsMatch(discount, query));
    }
    
    public Domain.Entities.Discount? ResolveBestDiscount(List<Domain.Entities.Discount> allDiscounts, GetBestDiscountForSaleQuery query)
    {
        return allDiscounts
            .Where(d => IsApplicable(d, query))
            .OrderByDescending(d => d.Priority) 
            .ThenByDescending(d => d.DiscountPercent) 
            .FirstOrDefault();
    }
}