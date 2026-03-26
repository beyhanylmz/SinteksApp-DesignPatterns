using Ardalis.Specification;
using SinteksApp.Application.Features.Bonus.Queries;
using SinteksApp.Application.Features.Bonus.Specs;
using SinteksApp.Domain.Entities;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public class CombinedBonusStrategy(
    IRepositoryBase<EmployeeMonthlySales> employeeSalesRepo,
    IRepositoryBase<BranchMonthlySalesLimit> limitRepo) 
    : IBonusCalculationStrategy
{
    public BonusType Type => BonusType.Combined;

    
    public async Task<decimal> CalculateAsync(BonusDefinition def, Domain.Entities.Employee employee, CalculateEmployeeBonusQuery query, decimal branchTotalSales, CancellationToken ct)
    {
        // 1. Kısım: Kişisel Satışa Göre Sabit Bonus (Fixed Mantığı)
        var personalSales = await employeeSalesRepo.FirstOrDefaultAsync(
            new EmployeeMonthlySalesSpec(employee.Id, query.Year, query.Month), ct);
        
        var personalSalesAmount = personalSales?.TotalNetSalesAmount ?? 0m;

        var rule = def.Rules
            .Where(x => (x.JobPositionId == null || x.JobPositionId == employee.JobPositionId) 
                        && x.BonusAmount.HasValue 
                        && x.MinSales <= personalSalesAmount)
            .OrderByDescending(x => x.MinSales)
            .FirstOrDefault();

        var baseBonus = rule?.BonusAmount ?? 0m;

        // 2. Kısım: Şube Limiti Geçildiyse Ekstra Bonus
        var extra = def.ExtraBonusIfLimitExceeded ?? 0m;
        if (extra <= 0m) return baseBonus;

        var limit = await limitRepo.FirstOrDefaultAsync(new BranchMonthlySalesLimitSpec(employee.CurrentBranchId, query.Year, query.Month), ct);

        if (limit != null && branchTotalSales > limit.LimitAmount)
        {
            return baseBonus + extra;
        }

        return baseBonus;
    }
}