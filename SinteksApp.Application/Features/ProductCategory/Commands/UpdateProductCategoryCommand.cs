using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.ProductCategory.Commands;

public record UpdateProductCategoryCommand(int Id, string Name) : IRequest<Result>;

public class UpdateProductCategoryCommandHandler(IRepositoryBase<Domain.Entities.ProductCategory> repository)
    : IRequestHandler<UpdateProductCategoryCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return Result.Fail(new NotFoundError($"ProductCategory with Id {request.Id} not found"));

        request.Adapt(entity);
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
