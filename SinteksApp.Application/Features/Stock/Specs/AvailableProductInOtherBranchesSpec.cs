using Ardalis.Specification;

namespace SinteksApp.Application.Features.Stock.Specs;

public class AvailableProductInOtherBranchesSpec
    : Specification<Domain.Entities.Stock>
{
    public AvailableProductInOtherBranchesSpec(
        int productId,
        string color,
        string size,
        int excludedBranchId)
    {
        Query.Include(s => s.Product)
            .Include(x=> x.Branch)
            .Where(s =>
                s.ProductId == productId &&
                s.Product.Color == color &&
                s.Product.Size == size &&
                s.BranchId != excludedBranchId &&
                s.Quantity > 0);
    }
}
