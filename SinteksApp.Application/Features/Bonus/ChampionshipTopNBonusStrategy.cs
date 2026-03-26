using Ardalis.Specification;
using SinteksApp.Application.Features.Bonus.Queries;
using SinteksApp.Application.Features.Bonus.Specs;
using SinteksApp.Domain.Entities;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public class ChampionshipTopNBonusStrategy(IRepositoryBase<EmployeeMonthlySales> salesRepo, IRepositoryBase<BranchMonthlySalesLimit> limitRepo) : IBonusCalculationStrategy
{
    public BonusType Type => BonusType.ChampionshipTopN;

    public async Task<decimal> CalculateAsync(BonusDefinition def, Domain.Entities.Employee employee, CalculateEmployeeBonusQuery query, decimal branchTotalSales, CancellationToken ct)
    {
        var limit = await limitRepo.FirstOrDefaultAsync(
            new BranchMonthlySalesLimitSpec(employee.CurrentBranchId, query.Year, query.Month), ct);
        
        if (limit == null || branchTotalSales <= limit.LimitAmount) return 0m;
        
        var topN = def.TopN ?? 0;
        if (topN <= 0) return 0m;

        // Belirli aydaki ilk N satışı getir
        var topSales = await salesRepo.ListAsync(
            new TopNEmployeesSalesSpec(employee.CurrentBranchId, query.Year, query.Month, topN), ct);

        // Çalışanın sıralamasını bul (0-index tabanlı olduğu için +1 ekle)
        var index = topSales.FindIndex(x => x.EmployeeId == employee.Id);
        if (index < 0) return 0m;

        var rank = index + 1;

        // Tanımlanan kurallardan bu sıralamaya (rank) denk geleni bul
        var rule = def.Rules.FirstOrDefault(x => x.Rank == rank && x.BonusAmount.HasValue);
        return rule?.BonusAmount ?? 0m;
    }
}