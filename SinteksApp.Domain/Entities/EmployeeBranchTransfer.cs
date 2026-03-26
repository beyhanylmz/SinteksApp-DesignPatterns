using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class EmployeeBranchTransfer : BaseEntity
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = default!;

    public int OldBranchId { get; set; }
    public int NewBranchId { get; set; }
    public DateTime TransferDate { get; set; }
}
