using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    
    //Alış fiyatı  Cost price
    public decimal PurchasePrice { get; set; }
    
    // discount uygulanmadan onceki fiyati
    public decimal BaseSalePrice { get; set; }
    public string Color { get; set; } = null!;
    public string Size { get; set; } = null!;
    
    public int BrandId { get; set; }
    public int ProductCategoryId { get; set; }
    public Brand Brand { get; set; } = null!;
    public ProductCategory ProductCategory { get; set; } = null!;
    public ICollection<BranchProductAssortment> BranchProductAssortments { get; set; } = new List<BranchProductAssortment>();
    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
