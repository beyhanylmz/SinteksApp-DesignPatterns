using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.SubCompany.Commands;

public record DeleteSubCompanyCommand(int Id) : IRequest<Result>;

public class DeleteSubCompanyCommandHandler(IRepositoryBase<Domain.Entities.SubCompany> repository)
    : IRequestHandler<DeleteSubCompanyCommand, Result>
{
    public async Task<Result> Handle(DeleteSubCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"SubCompany with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}