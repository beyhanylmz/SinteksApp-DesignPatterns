using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.Brand.Response;

namespace SinteksApp.Application.Features.Brand.Queries;

public record GetAllBrandsQuery : IRequest<Result<List<BrandListResponse>>>;

public class GetAllBrandesQueryHandler(IReadRepositoryBase<Domain.Entities.Brand> repo) : IRequestHandler<GetAllBrandsQuery, Result<List<BrandListResponse>>>
{
    public async Task<Result<List<BrandListResponse>>> Handle(GetAllBrandsQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var data = await repo.ListAsync(cancellationToken);
            var result = data.Adapt<List<BrandListResponse>>();
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            return Result.Fail<List<BrandListResponse>>(new Error("Failed to retrieve Brandes").WithMetadata("exception", ex.Message));
        }
    }
}
