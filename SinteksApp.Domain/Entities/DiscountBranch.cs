using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class DiscountBranch : BaseEntity
{
    public int DiscountId { get; set; }
    public Discount Discount { get; set; } = null!;

    public int BranchId { get; set; }
    public Branch Branch { get; set; } = null!;
}