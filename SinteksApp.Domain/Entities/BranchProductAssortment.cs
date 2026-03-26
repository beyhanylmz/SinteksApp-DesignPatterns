using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class BranchProductAssortment : BaseEntity
{
    public int BranchId { get; set; }
    public int ProductId { get; set; }
    public bool IsAvailable { get; set; }
   
    public Branch Branch { get; set; } = null!;
    public Product Product { get; set; } = null!;

}
