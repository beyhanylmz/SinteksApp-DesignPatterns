using Ardalis.Specification;
using FluentResults;
using MediatR;

namespace SinteksApp.Application.Features.Discount.Queries;

public record GetBestDiscountForSaleQuery(
    int? BranchId,
    int ProductId,
    int? CategoryId,
    int? BrandId,
    DateTime SaleDateUtc
) : IRequest<Result<BestDiscountDto>>;

public class GetBestDiscountForSaleQueryHandler(
    IRepositoryBase<Domain.Entities.Discount> repo,
    IDiscountEngine discountEngine
) : IRequestHandler<GetBestDiscountForSaleQuery, Result<BestDiscountDto>>
{
    public async Task<Result<BestDiscountDto>> Handle(GetBestDiscountForSaleQuery request, CancellationToken ct)
    {
        // 1. Sadece aktif indirimler
        var discounts = await repo.ListAsync(
            new ActiveDiscountsForSaleSpec(request.SaleDateUtc, request.BranchId), 
            ct);

        // 2. İş mantığını motora devret (Best Discount'u motor seçsin)
        // Tüm Priority ve Applicable logic artık bu metodun içinde
        var best = discountEngine.ResolveBestDiscount(discounts, request);

        // 3. Sonucu dön
        return Result.Ok(best is null
            ? new BestDiscountDto(null, 0)
            : new BestDiscountDto(best.Id, best.DiscountPercent));
    }
}