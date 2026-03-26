using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.Brand.Response;

namespace SinteksApp.Application.Features.Brand.Queries;

public record GetBrandByIdQuery(int Id) : IRequest<Result<BrandDetailResponse>>;

public class GetBrandByIdQueryHandler(IReadRepositoryBase<Domain.Entities.Brand> repo) : IRequestHandler<GetBrandByIdQuery,  Result<BrandDetailResponse>>
{
    public async Task<Result<BrandDetailResponse>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken) 
    {
        var brand = await repo.GetByIdAsync(request.Id,cancellationToken);
        if (brand is null)
            return Result.Fail<BrandDetailResponse>(new NotFoundError("Barand not found."));
        
        var brandResponse = brand.Adapt<BrandDetailResponse>();
        return Result.Ok(brandResponse);
    }
}
