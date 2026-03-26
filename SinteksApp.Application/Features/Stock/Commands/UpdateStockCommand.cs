using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Stock.Commands;

public record UpdateStockCommand(int Id,   
    int BranchId,
    int ProductId,
    int Quantity,
    int? MinStock,
    int? MaxStock) : IRequest<Result>;

public class UpdateStockCommandHandler(IRepositoryBase<Domain.Entities.Stock> repository)
    : IRequestHandler<UpdateStockCommand, Result>
{
    public async Task<Result> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return Result.Fail(new NotFoundError($"Stock with Id {request.Id} not found"));

        request.Adapt(entity);
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
