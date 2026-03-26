using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public class ProductStrategy : IDiscountStrategy
{
    public bool IsMatch(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query) =>
        discount.Products.Any(x => x.ProductId == query.ProductId);
}