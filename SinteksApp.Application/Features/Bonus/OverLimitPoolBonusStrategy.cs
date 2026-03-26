using Ardalis.Specification;
using SinteksApp.Application.Features.Bonus.Queries;
using SinteksApp.Application.Features.Bonus.Specs;
using SinteksApp.Domain.Entities;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public class OverLimitPoolBonusStrategy(
    IRepositoryBase<BranchMonthlySalesLimit> limitRepo,
    IRepositoryBase<Domain.Entities.Employee> employeeRepo) 
    : IBonusCalculationStrategy
{
    public BonusType Type => BonusType.OverLimitPool;

    public async Task<decimal> CalculateAsync(BonusDefinition def, Domain.Entities.Employee employee, CalculateEmployeeBonusQuery query, decimal branchTotalSales, CancellationToken ct)
    {
        var limit = await limitRepo.FirstOrDefaultAsync(
            new BranchMonthlySalesLimitSpec(employee.CurrentBranchId, query.Year, query.Month), ct);
        
        if (limit == null || branchTotalSales <= limit.LimitAmount) return 0m;

        // bonus pool
        var poolPercent = def.OverLimitPoolPercent ?? 0m;
        if (poolPercent <= 0) return 0m;

        // Havuz miktarını hesapla: (Toplam Satış - Limit) * Yüzde
        var excess = branchTotalSales - limit.LimitAmount;
        var totalPool = excess * (poolPercent / 100m);

        // Şubede o ay aktif satışı olan personel sayısı
        var activeEmployees = await employeeRepo.ListAsync(new AllEmployeesInBranchMonthSpec(employee.CurrentBranchId, query.Year, query.Month), ct);
        
        if (activeEmployees.Count == 0) 
            return 0m;

        return totalPool / activeEmployees.Count;
    }
}