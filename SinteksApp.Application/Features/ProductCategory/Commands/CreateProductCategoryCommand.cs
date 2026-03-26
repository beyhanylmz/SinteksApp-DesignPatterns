using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.ProductCategory.Commands;

public record CreateProductCategoryCommand(
    string Name) : IRequest<Result<int>>;

public class CreateProductCategoryCommandHandler(IRepositoryBase<Domain.Entities.ProductCategory> repository)
    : IRequestHandler<CreateProductCategoryCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.ProductCategory>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);             
    }
}