using SinteksApp.Domain.Common;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Domain.Entities;

public class Discount : BaseEntity
{
    public string Name { get; set; } = default!;

    /// <summary>
    /// Standard, BlackFriday, NewYear, Seasonal, etc.
    /// </summary>
    public DiscountType Type { get; set; }
    public decimal DiscountPercent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Priority { get; set; }
    
    //TODO
    public bool AppliesToAllBranches { get; set; }
    public bool AppliesToAllProducts { get; set; }
    public bool AppliesToAllCategories { get; set; }
    public bool AppliesToAllBrands { get; set; }

    public ICollection<DiscountBranch> Branches { get; set; } = new List<DiscountBranch>();
    public ICollection<DiscountProduct> Products { get; set; } = new List<DiscountProduct>();
    public ICollection<DiscountCategory> Categories { get; set; } = new List<DiscountCategory>();
    public ICollection<DiscountBrand> Brands { get; set; } = new List<DiscountBrand>();
    public ICollection<DiscountExcludedProduct> ExcludedProducts { get; set; } = new List<DiscountExcludedProduct>();
}