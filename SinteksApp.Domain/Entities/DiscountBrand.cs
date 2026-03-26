using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class DiscountBrand : BaseEntity
{
    public int DiscountId { get; set; }
    public Discount Discount { get; set; } = null!;

    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;
}