using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class BranchMonthlySalesLimitSpec : Specification<BranchMonthlySalesLimit>
{
    public BranchMonthlySalesLimitSpec(int branchId, int year, int month)
    {
        Query.Where(x => x.BranchId == branchId && x.Year == year && x.Month == month);
    }
}