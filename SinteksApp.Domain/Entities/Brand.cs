using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class Brand : BaseEntity
{
    public int SubCompanyId { get; set; }
    public string Name { get; set; } = null!;
    
    public List<BrandSubCompanyAssignment> SubCompanyAssignments { get; set; } = new();
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}