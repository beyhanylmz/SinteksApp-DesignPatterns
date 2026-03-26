using Ardalis.Specification;

namespace SinteksApp.Application.Features.Sale.Specs;

public class StockByBranchAndProductSpec
    : Specification<Domain.Entities.Stock>
{
    public StockByBranchAndProductSpec(int branchId, int productId)
    {
        Query.Where(s =>
            s.BranchId == branchId && s.ProductId == productId);
    }
}
