using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Branch.Commands;

public record DeleteBranchCommand(int Id) : IRequest<Result>;

public class DeleteBranchCommandHandler(IRepositoryBase<Domain.Entities.Branch> repository)
    : IRequestHandler<DeleteBranchCommand, Result>
{
    public async Task<Result> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"Branch with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}