using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.Brand.Commands;

public record CreateBrandCommand(string Name, int SubCompanyId) : IRequest<Result<int>>;

public class CreateBrandCommandHandler(IRepositoryBase<Domain.Entities.Brand> repository) : IRequestHandler<CreateBrandCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.Brand>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);
    }
    
}