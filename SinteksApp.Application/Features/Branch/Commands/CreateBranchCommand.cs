using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.Branch.Commands;

public record CreateBranchCommand(string Name, string Address, int BrandId) : IRequest<Result<int>>;


public class CreateBranchCommandHandler(IRepositoryBase<Domain.Entities.Branch> repository) : IRequestHandler<CreateBranchCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.Branch>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);
    }
    
}