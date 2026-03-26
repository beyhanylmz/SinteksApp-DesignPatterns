using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class EmployeeMonthlySalarySpec : Specification<EmployeeMonthlySalary>
{
    public EmployeeMonthlySalarySpec(int employeeId, int branchId, int year, int month)
    {
        Query.Where(x => x.EmployeeId == employeeId && x.BranchId == branchId && x.Year == year && x.Month == month);
    }
}