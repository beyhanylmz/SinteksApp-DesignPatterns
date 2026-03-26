using Ardalis.Specification;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class BranchMonthlySalesSumSpec : Specification<Domain.Entities.Sale>
{
    public BranchMonthlySalesSumSpec(int branchId, int year, int month)
    {
        Query.Where(x => x.BranchId == branchId && x.SaleDate.Year == year && x.SaleDate.Month == month);
    }
}