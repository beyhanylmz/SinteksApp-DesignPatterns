using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}