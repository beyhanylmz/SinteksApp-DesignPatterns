using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class EmployeeMonthlySalesSpec : Specification<EmployeeMonthlySales>
{
    public EmployeeMonthlySalesSpec(int employeeId, int year, int month)
    {
        Query.Where(x => x.EmployeeId == employeeId && x.Year == year && x.Month == month);
    }
}