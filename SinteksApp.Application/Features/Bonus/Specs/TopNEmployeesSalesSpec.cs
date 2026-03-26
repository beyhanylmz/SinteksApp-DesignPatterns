using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class TopNEmployeesSalesSpec : Specification<EmployeeMonthlySales>
{
    public TopNEmployeesSalesSpec(int branchId, int year, int month, int topN)
    {
        Query.Where(x => x.BranchId == branchId && x.Year == year && x.Month == month)
            .OrderByDescending(x => x.TotalNetSalesAmount)
            .Take(topN);
    }
}