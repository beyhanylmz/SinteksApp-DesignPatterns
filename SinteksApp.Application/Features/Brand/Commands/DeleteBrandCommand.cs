using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Brand.Commands;

public record DeleteBrandCommand(int Id) : IRequest<Result>;

public class DeleteBrandCommandHandler(IRepositoryBase<Domain.Entities.Brand> repository)
    : IRequestHandler<DeleteBrandCommand, Result>
{
    public async Task<Result> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"Brand with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}