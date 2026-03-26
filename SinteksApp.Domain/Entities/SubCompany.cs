using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class SubCompany : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<Brand> Brands { get; set; } = new ();
    
    public List<BrandSubCompanyAssignment> BrandAssignments { get; set; } = new();
}
