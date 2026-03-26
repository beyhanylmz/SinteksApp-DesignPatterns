using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.BranchProductAssortment.Commands;

public record UpdateBranchProductAssortmentCommand(int Id, int BranchId , int ProductId, bool IsAvailable): IRequest<Result>;

public class UpdateBranchProductAssortmentCommandHandler(IRepositoryBase<Domain.Entities.BranchProductAssortment> repository)
    : IRequestHandler<UpdateBranchProductAssortmentCommand, Result>
{
    public async Task<Result> Handle(UpdateBranchProductAssortmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return Result.Fail(new NotFoundError($"BranchProductAssortment with Id {request.Id} not found"));

        request.Adapt(entity);
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
