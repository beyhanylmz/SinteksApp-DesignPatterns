using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class EmployeeMonthlySalary : BaseEntity
{
    public int EmployeeId { get; set; }
    public int BranchId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public decimal SalaryAmount { get; set; }
}