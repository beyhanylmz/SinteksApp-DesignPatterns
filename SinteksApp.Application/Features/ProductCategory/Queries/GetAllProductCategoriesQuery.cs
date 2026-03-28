using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.ProductCategory.Response;

namespace SinteksApp.Application.Features.ProductCategory.Queries;

public record GetAllProductCategoriesQuery : IRequest<Result<List<ProductCategoryListResponse>>>;

public class GetAllProductCategoriesQueryHandler(IReadRepositoryBase<Domain.Entities.ProductCategory> repo)
    : IRequestHandler<GetAllProductCategoriesQuery, Result<List<ProductCategoryListResponse>>>
{
    public async Task<Result<List<ProductCategoryListResponse>>> Handle(GetAllProductCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var data = await repo.ListAsync(cancellationToken);
        var result = data.Adapt<List<ProductCategoryListResponse>>();
        return Result.Ok(result);
    }
}