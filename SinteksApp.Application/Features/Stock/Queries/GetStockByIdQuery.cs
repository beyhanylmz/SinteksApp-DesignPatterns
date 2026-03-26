using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.Stock.Response;

namespace SinteksApp.Application.Features.Stock.Queries;

public record GetStockByIdQuery(int Id) : IRequest<Result<StockDetailResponse>>;

public class GetStockByIdQueryHandler(IReadRepositoryBase<Domain.Entities.Stock> repo)
    : IRequestHandler<GetStockByIdQuery, Result<StockDetailResponse>>
{
    public async Task<Result<StockDetailResponse>> Handle(GetStockByIdQuery request,
        CancellationToken cancellationToken)
    {
        var Stock = await repo.GetByIdAsync(request.Id, cancellationToken);
        if (Stock is null)
            return Result.Fail<StockDetailResponse>(new NotFoundError("Stock not found."));

        var response = Stock.Adapt<StockDetailResponse>();
        return Result.Ok(response);
    }
}