using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class DiscountProduct : BaseEntity
{
    public int DiscountId { get; set; }
    public Discount Discount { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}