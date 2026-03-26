using SinteksApp.Domain.Common;

namespace SinteksApp.Domain.Entities;

public class BonusRule : BaseEntity
{
    public int BonusDefinitionId { get; set; }
    public BonusDefinition BonusDefinition { get; set; } = default!;
    
    // For FIXED/COMBINED personal bonus: MinSales = personal sales threshold
    // Fixed Bonus System
    // Sales Representative
    // 10,000 AZN sales → 300 AZN
    // 20,000 AZN sales → 500 AZN
    
    // For PERCENT: MinSales = store (branch) sales threshold
    // Percentage-Based Bonus System
    // Store sales > 60,000 → 6% of salary
    // Store sales > 90,000 → 9% of salary
    public decimal MinSales { get; set; }

    // Fixed amount bonus
    public decimal? BonusAmount { get; set; }

    // Percent bonus (percent of salary), ex: 6 => 6%
    public decimal? BonusPercent { get; set; }

    // For Championship (rank 1..N)
    public int? Rank { get; set; }

    // per-position rules
    public int? JobPositionId { get; set; }
}
