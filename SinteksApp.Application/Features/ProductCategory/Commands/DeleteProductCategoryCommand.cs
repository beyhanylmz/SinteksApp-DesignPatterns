using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.ProductCategory.Commands;

public record DeleteProductCategoryCommand(int Id) : IRequest<Result>;

public class DeleteProductCategoryCommandHandler(IRepositoryBase<Domain.Entities.ProductCategory> repository)
    : IRequestHandler<DeleteProductCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (entity == null)  return Result.Fail(new NotFoundError($"ProductCategory with Id {request.Id} not found"));

        entity.IsDeleted = true;
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}