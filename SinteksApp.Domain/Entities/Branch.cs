using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class Branch : BaseEntity
{
    public int BrandId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool HasCustomStockPolicy { get; set; }
    public bool HasAssortmentPolicy { get; set; }
    public bool HasCustomDiscountPolicy { get; set;}

    public Brand Brand { get; set; } = null!;
    public ICollection<BranchProductAssortment> BranchProductAssortments { get; set; } = new List<BranchProductAssortment>();
    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
