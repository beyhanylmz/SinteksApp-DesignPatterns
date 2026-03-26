using Ardalis.Specification;
using FluentResults;
using Mapster;
using MediatR;

namespace SinteksApp.Application.Features.Product.Commands;

public record CreateProductCommand(string Name, decimal PurchasePrice, decimal BaseSalePrice, string Color,
 string Size,int BrandId, int ProductCategoryId) : IRequest<Result<int>>;


public class CreateProductCommandHandler(IRepositoryBase<Domain.Entities.Product> repository) : IRequestHandler<CreateProductCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Domain.Entities.Product>();
        await repository.AddAsync(entity, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Ok(entity.Id);
    }
    
}