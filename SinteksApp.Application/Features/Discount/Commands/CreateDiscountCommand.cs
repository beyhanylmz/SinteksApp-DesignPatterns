using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Discount.Commands;

public record CreateDiscountCommand(
    string Name,
    DiscountType Type,
    decimal DiscountPercent,
    DateTime StartDate,
    DateTime EndDate,
    int Priority,
    bool IsActive,
    IReadOnlyCollection<int>? BranchIds,
    IReadOnlyCollection<int>? ProductIds,
    IReadOnlyCollection<int>? CategoryIds,
    IReadOnlyCollection<int>? BrandIds,
    IReadOnlyCollection<int>? ExcludedProductIds
) : IRequest<Result<int>>;

public class CreateDiscountCommandHandler(IRepositoryBase<Domain.Entities.Discount> repo)
    : IRequestHandler<CreateDiscountCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateDiscountCommand command, CancellationToken ct)
    {
        var discount = command.Adapt<Domain.Entities.Discount>();
        await repo.AddAsync(discount, ct);
        await repo.SaveChangesAsync(ct);
        return Result.Ok(discount.Id);
    }
}