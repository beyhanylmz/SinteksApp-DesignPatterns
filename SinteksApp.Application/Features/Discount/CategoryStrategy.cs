using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public class CategoryStrategy : IDiscountStrategy
{
    public bool IsMatch(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query) =>
        query.CategoryId.HasValue && discount.Categories.Any(x => x.CategoryId == query.CategoryId.Value);
}