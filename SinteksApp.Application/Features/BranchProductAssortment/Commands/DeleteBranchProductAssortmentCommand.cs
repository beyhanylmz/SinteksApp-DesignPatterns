using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.BranchProductAssortment.Commands;

public record DeleteBranchProductAssortmentCommand(int Id) : IRequest<Result>;

public class DeleteBranchProductAssortmentCommandHandler(IRepositoryBase<Domain.Entities.BranchProductAssortment> repository)
    : IRequestHandler<DeleteBranchProductAssortmentCommand, Result>
{
    public async Task<Result> Handle(DeleteBranchProductAssortmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"BranchProductAssortment with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}