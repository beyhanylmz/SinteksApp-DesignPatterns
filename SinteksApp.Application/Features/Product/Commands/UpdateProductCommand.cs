using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;
using SinteksApp.Application.Common.Errors;

namespace SinteksApp.Application.Features.Product.Commands;

public record UpdateProductCommand(int Id, string Name, decimal PurchasePrice, decimal BaseSalePrice, string Color,
    string Size, int BrandId, int ProductCategoryId) : IRequest<Result>;

public class UpdateProductCommandHandler(IRepositoryBase<Domain.Entities.Product> repository)
    : IRequestHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity == null)
            return Result.Fail(new NotFoundError($"Product with Id {request.Id} not found"));

        request.Adapt(entity);
        await repository.UpdateAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
