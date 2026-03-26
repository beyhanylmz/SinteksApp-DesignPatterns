using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Stock.Commands;

public record DeleteStockCommand(int Id) : IRequest<Result>;

public class DeleteStockCommandHandler(IRepositoryBase<Domain.Entities.Stock> repository)
    : IRequestHandler<DeleteStockCommand, Result>
{
    public async Task<Result> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"Stock with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}