using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class DiscountCategory : BaseEntity
{
    public int DiscountId { get; set; }
    public Discount Discount { get; set; } = null!;

    public int CategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; } = null!;
}