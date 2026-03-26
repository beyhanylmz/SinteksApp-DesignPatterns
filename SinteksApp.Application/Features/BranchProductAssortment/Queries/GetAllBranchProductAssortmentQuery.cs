using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.BranchProductAssortment.Response;

namespace SinteksApp.Application.Features.BranchProductAssortment.Queries;

public record GetAllBranchProductAssortmentQuery : IRequest<Result<List<BranchProductAssortmentListResponse>>>;

public class GetAllProductCategoriesQueryHandler(IReadRepositoryBase<Domain.Entities.BranchProductAssortment> repo) : IRequestHandler<GetAllBranchProductAssortmentQuery, Result<List<BranchProductAssortmentListResponse>>>
{
    public async Task<Result<List<BranchProductAssortmentListResponse>>> Handle(GetAllBranchProductAssortmentQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var data = await repo.ListAsync(cancellationToken);
            var result = data.Adapt<List<BranchProductAssortmentListResponse>>();
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            return Result.Fail<List<BranchProductAssortmentListResponse>>(new Error("Failed to retrieve ProductCategories").WithMetadata("exception", ex.Message));
        }
    }
}
