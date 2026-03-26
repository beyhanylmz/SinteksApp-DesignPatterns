using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class BrandSubCompanyAssignment : BaseEntity
{
    public int BrandId { get; set; }
    public int SubCompanyId { get; set; }
    public DateTime StartDateUtc { get; set; }
    public DateTime? EndDateUtc { get; set; }

    public string? Note { get; set; } // Reason etc
    public string? ChangedBy { get; set; }
    
    public Brand Brand { get; set; } = null!;
    public SubCompany SubCompany { get; set; } = null!;
}