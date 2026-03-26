using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public class BrandStrategy : IDiscountStrategy
{
    public bool IsMatch(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query) =>
        discount.Brands.Any(x => x.BrandId == query.BrandId);
}