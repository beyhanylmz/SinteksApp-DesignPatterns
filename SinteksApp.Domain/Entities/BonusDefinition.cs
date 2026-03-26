using SinteksApp.Domain.Common;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Domain.Entities;
public class BonusDefinition : BaseEntity
{
    public string Name { get; set; } = default!;
    public BonusType Type { get; set; }
    public int BranchId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public bool IsActive { get; set; } = true;
    public int? TopN { get; set; } // Championship
    public decimal? OverLimitPoolPercent { get; set; } // OverLimitPool, e.g. 10 => 10%
    public decimal? ExtraBonusIfLimitExceeded { get; set; } // Combined
    public List<BonusRule> Rules { get; set; } = new();
}
