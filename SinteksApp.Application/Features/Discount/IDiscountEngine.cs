using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public interface IDiscountEngine
{
    Domain.Entities.Discount? ResolveBestDiscount(List<Domain.Entities.Discount> candidates, GetBestDiscountForSaleQuery query);
}