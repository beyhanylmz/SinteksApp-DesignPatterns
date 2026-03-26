using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;
using SinteksApp.Application.Features.BranchProductAssortment.Response;

namespace SinteksApp.Application.Features.BranchProductAssortment.Queries;

public record GetBranchProductAssortmentByIdQuery(int Id) : IRequest<Result<BranchProductAssortmentDetailResponse>>;

public class GetBranchProductAssortmentByIdQueryHandler(IReadRepositoryBase<Domain.Entities.BranchProductAssortment> repo)
    : IRequestHandler<GetBranchProductAssortmentByIdQuery, Result<BranchProductAssortmentDetailResponse>>
{
    public async Task<Result<BranchProductAssortmentDetailResponse>> Handle(GetBranchProductAssortmentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var branchProductAssortment = await repo.GetByIdAsync(request.Id, cancellationToken);
        if (branchProductAssortment is null)
            return Result.Fail<BranchProductAssortmentDetailResponse>(new NotFoundError("BranchProductAssortment not found."));

        var response = branchProductAssortment.Adapt<BranchProductAssortmentDetailResponse>();
        return Result.Ok(response);
    }
}