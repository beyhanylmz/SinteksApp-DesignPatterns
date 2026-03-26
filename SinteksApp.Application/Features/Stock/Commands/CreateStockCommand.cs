using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.Stock.Commands;

public record CreateStockCommand(
    int BranchId,
    int ProductId,
    int Quantity,
    int? MinStock,
    int? MaxStock) : IRequest<Result<int>>;

public class CreateStockCommandHandler(IRepositoryBase<Domain.Entities.Stock> repository)
    : IRequestHandler<CreateStockCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.Stock>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);
    }
}