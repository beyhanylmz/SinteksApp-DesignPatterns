using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class EmployeeMonthlySales : BaseEntity
{
    public int EmployeeId { get; set; }
    public int BranchId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int TotalSalesCount { get; set; }
    public decimal TotalNetSalesAmount { get; set; }
    public int ReturnedSalesCount { get; set; }
    public decimal ReturnedSalesAmount { get; set; }
}
