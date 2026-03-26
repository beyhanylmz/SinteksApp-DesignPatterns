using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public class BranchSpecification : DiscountSpecification
{
    public override bool IsSatisfiedBy(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query) =>
        !discount.Branches.Any() || (query.BranchId.HasValue && discount.Branches.Any(x => x.BranchId == query.BranchId));
}