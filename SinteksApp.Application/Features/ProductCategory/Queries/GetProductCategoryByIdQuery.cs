using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.ProductCategory.Response;

namespace SinteksApp.Application.Features.ProductCategory.Queries;

public record GetProductCategoryByIdQuery(int Id) : IRequest<Result<ProductCategoryDetailResponse>>;

public class GetProductCategoryByIdQueryHandler(IReadRepositoryBase<Domain.Entities.ProductCategory> repo)
    : IRequestHandler<GetProductCategoryByIdQuery, Result<ProductCategoryDetailResponse>>
{
    public async Task<Result<ProductCategoryDetailResponse>> Handle(GetProductCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var productCategory = await repo.GetByIdAsync(request.Id, cancellationToken);
        if (productCategory is null)
            return Result.Fail<ProductCategoryDetailResponse>(new NotFoundError("ProductCategory not found."));

        var response = productCategory.Adapt<ProductCategoryDetailResponse>();
        return Result.Ok(response);
    }
}