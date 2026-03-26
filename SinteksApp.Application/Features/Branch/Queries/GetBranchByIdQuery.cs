using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.Branch.Response;

namespace SinteksApp.Application.Features.Branch.Queries;

public record GetBranchByIdQuery(int Id) : IRequest<Result<BranchDetailResponse>>;

public class GetBranchByIdQueryHandler(IReadRepositoryBase<Domain.Entities.Branch> repo)
    : IRequestHandler<GetBranchByIdQuery, Result<BranchDetailResponse>>
{
    public async Task<Result<BranchDetailResponse>> Handle(GetBranchByIdQuery request,
        CancellationToken cancellationToken)
    {
        var branch = await repo.GetByIdAsync(request.Id, cancellationToken);
        if (branch is null)
            return Result.Fail<BranchDetailResponse>(new NotFoundError("Branch not found."));

        var branchResponse = branch.Adapt<BranchDetailResponse>();
        return Result.Ok(branchResponse);
    }
}