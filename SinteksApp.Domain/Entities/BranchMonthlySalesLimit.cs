using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class BranchMonthlySalesLimit : BaseEntity
{
    public int BranchId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public decimal LimitAmount { get; set; }
}