using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.SubCompany.Commands;

public record CreateSubCompanyCommand(string Name) : IRequest<Result<int>>;

public class CreateSubCompanyCommandHandler(IRepositoryBase<Domain.Entities.SubCompany> repository) : IRequestHandler<CreateSubCompanyCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateSubCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.SubCompany>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);
    }
    
}