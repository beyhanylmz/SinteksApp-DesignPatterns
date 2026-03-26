using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public abstract class DiscountSpecification
{
    public abstract bool IsSatisfiedBy(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query);
}