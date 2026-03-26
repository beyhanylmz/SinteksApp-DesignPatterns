using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.Product.Response;

namespace SinteksApp.Application.Features.Product.Queries;

public record GetAllProductsQuery : IRequest<Result<List<ProductListResponse>>>;

public class GetAllProductsQueryHandler(IReadRepositoryBase<Domain.Entities.Product> repo) : IRequestHandler<GetAllProductsQuery, Result<List<ProductListResponse>>>
{
    public async Task<Result<List<ProductListResponse>>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            //TODO: Maybe can calculate the discounted price while show
            var data = await repo.ListAsync(cancellationToken);
            var result = data.Adapt<List<ProductListResponse>>();
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            return Result.Fail<List<ProductListResponse>>(new Error("Failed to retrieve Productes").WithMetadata("exception", ex.Message));
        }
    }
}
