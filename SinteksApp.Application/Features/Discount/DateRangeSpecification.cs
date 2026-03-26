using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public class DateRangeSpecification : DiscountSpecification
{
    public override bool IsSatisfiedBy(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query) =>
        query.SaleDateUtc >= discount.StartDate && query.SaleDateUtc <= discount.EndDate;
}