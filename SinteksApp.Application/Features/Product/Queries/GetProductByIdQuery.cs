using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.Product.Response;

namespace SinteksApp.Application.Features.Product.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Result<ProductDetailResponse>>;

public class GetProductByIdQueryHandler(IReadRepositoryBase<Domain.Entities.Product> repo)
    : IRequestHandler<GetProductByIdQuery, Result<ProductDetailResponse>>
{
    public async Task<Result<ProductDetailResponse>> Handle(GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var Product = await repo.GetByIdAsync(request.Id, cancellationToken);
        if (Product is null)
            return Result.Fail<ProductDetailResponse>(new NotFoundError("Product not found."));

        var ProductResponse = Product.Adapt<ProductDetailResponse>();
        return Result.Ok(ProductResponse);
    }
}