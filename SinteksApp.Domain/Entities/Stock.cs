using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class Stock : BaseEntity
{
    public int BranchId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }
    public int? MinStock { get; set; }
    public int? MaxStock { get; set; }

    public Branch Branch { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
