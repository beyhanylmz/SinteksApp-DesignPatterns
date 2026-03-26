using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class DiscountExcludedProduct : BaseEntity
{
    public int DiscountId { get; set; }
    public Discount Discount { get; set; } = default!;

    public int ProductId { get; set; }
    
    public Product Product { get; set; } = default!;
    
}