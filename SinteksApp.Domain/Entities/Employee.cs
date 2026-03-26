using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class Employee : BaseEntity
{
    public string FullName { get; set; } = default!;
    public int CurrentBranchId { get; set; }
    public int? JobPositionId { get; set; }
    public List<EmployeeBranchTransfer> Transfers { get; set; } = new();
}
