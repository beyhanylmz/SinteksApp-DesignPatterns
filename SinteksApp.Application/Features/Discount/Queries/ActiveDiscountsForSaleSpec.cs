using Ardalis.Specification;

namespace SinteksApp.Application.Features.Discount.Queries;

public sealed class ActiveDiscountsForSaleSpec : Specification<Domain.Entities.Discount>
{
    public ActiveDiscountsForSaleSpec(DateTime saleDateUtc, int? requestBranchId)
    {
        Query
            .Where(d => d.IsActive
                        && d.StartDate <= saleDateUtc
                        && d.EndDate >= saleDateUtc && 
                        (!d.Branches.Any() || (requestBranchId.HasValue && d.Branches.Any(b => b.BranchId == requestBranchId))))
            .Include(d => d.Branches)
            .Include(d => d.Products)
            .Include(d => d.Categories)
            .Include(d => d.Brands)
            .Include(d => d.ExcludedProducts);
    }
}