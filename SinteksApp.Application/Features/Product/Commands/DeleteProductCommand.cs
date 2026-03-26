using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Product.Commands;

public record DeleteProductCommand(int Id) : IRequest<Result>;

public class DeleteProductCommandHandler(IRepositoryBase<Domain.Entities.Product> repository)
    : IRequestHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"Product with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}