using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.BranchProductAssortment.Commands;

public record CreateBranchProductAssortmentCommand( int BranchId , int ProductId, bool IsAvailable) : IRequest<Result<int>>;

public class CreateBranchProductAssortmentCommandHandler(IRepositoryBase<Domain.Entities.BranchProductAssortment> repository)
    : IRequestHandler<CreateBranchProductAssortmentCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBranchProductAssortmentCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.BranchProductAssortment>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);
    }
}