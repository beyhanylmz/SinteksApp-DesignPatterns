using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Features.Branch.Response;
using SinteksApp.Application.Features.Stock.Specs;

namespace SinteksApp.Application.Features.Stock.Queries;

public record CheckOtherBranchesQuery(
    int ProductId,
    string Color,
    string Size,
    int CurrentBranchId
) : IRequest<Result<List<BranchStockResponse>>>;

public class CheckOtherBranchesQueryHandler(IReadRepositoryBase<Domain.Entities.Stock> repository)
    : IRequestHandler<CheckOtherBranchesQuery, Result<List<BranchStockResponse>>>
{
    public async Task<Result<List<BranchStockResponse>>> Handle(
        CheckOtherBranchesQuery request,
        CancellationToken cancellationToken)
    {
        var spec = new AvailableProductInOtherBranchesSpec(
            request.ProductId,
            request.Color,
            request.Size,
            request.CurrentBranchId);

        var stocks = await repository.ListAsync(spec, cancellationToken);

        var result = stocks.Select(s => new BranchStockResponse(
            s.BranchId,
            s.Branch.Name,
            s.Quantity
        )).ToList();

        return Result.Ok(result);
    }
}

