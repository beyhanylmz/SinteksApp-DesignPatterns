using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Branch.Commands;

public record UpdateBranchCommand(int Id, string Name, string Address, int BrandId) : IRequest<Result>;

public class UpdateBranchCommandHandler(IRepositoryBase<Domain.Entities.Branch> repository)
    : IRequestHandler<UpdateBranchCommand, Result>
{
    public async Task<Result> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return Result.Fail(new NotFoundError($"Branch with Id {request.Id} not found"));

        request.Adapt(entity);
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
