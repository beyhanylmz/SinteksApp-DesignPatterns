using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Features.Branch.Response;

namespace SinteksApp.Application.Features.Branch.Queries;

public record GetAllBranchesQuery : IRequest<Result<List<BranchListResponse>>>;

public class GetAllBranchesQueryHandler(IReadRepositoryBase<Domain.Entities.Branch> repo) : IRequestHandler<GetAllBranchesQuery, Result<List<BranchListResponse>>>
{
    public async Task<Result<List<BranchListResponse>>> Handle(GetAllBranchesQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var data = await repo.ListAsync(cancellationToken);
            var result = data.Adapt<List<BranchListResponse>>();
            return Result.Ok(result);
        }
        catch (Exception ex)
        {
            return Result.Fail<List<BranchListResponse>>(new Error("Failed to retrieve branches").WithMetadata("exception", ex.Message));
        }
    }
}
