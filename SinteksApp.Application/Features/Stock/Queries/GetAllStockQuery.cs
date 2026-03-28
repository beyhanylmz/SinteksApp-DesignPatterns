using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.Stock.Response;

namespace SinteksApp.Application.Features.Stock.Queries;

public record GetAllStockQuery : IRequest<Result<List<StockListResponse>>>;

public class GetAllProductCategoriesQueryHandler(IReadRepositoryBase<Domain.Entities.Stock> repo)
    : IRequestHandler<GetAllStockQuery, Result<List<StockListResponse>>>
{
    public async Task<Result<List<StockListResponse>>> Handle(GetAllStockQuery request,
        CancellationToken cancellationToken)
    {
        var data = await repo.ListAsync(cancellationToken);
        var result = data.Adapt<List<StockListResponse>>();
        return Result.Ok(result);
    }
}