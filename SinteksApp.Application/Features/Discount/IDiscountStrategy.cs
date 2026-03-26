using SinteksApp.Application.Features.Discount.Queries;

namespace SinteksApp.Application.Features.Discount;

public interface IDiscountStrategy
{
    bool IsMatch(Domain.Entities.Discount discount, GetBestDiscountForSaleQuery query);
}