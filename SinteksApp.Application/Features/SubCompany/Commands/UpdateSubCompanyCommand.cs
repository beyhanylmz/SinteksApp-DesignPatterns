using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.SubCompany.Commands;

public record UpdateSubCompanyCommand(int Id, string Name) : IRequest<Result>;

public class UpdateSubCompanyCommandHandler(IRepositoryBase<Domain.Entities.SubCompany> repo)
    : IRequestHandler<UpdateSubCompanyCommand, Result>
{
    public async Task<Result> Handle(UpdateSubCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await repo.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return Result.Fail(new NotFoundError($"SubCompany with Id {request.Id} not found"));

        request.Adapt(entity);
        await repo.UpdateAsync(entity, cancellationToken);
        await repo.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
