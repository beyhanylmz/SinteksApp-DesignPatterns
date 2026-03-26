using Ardalis.Specification;
using SinteksApp.Application.Features.Bonus.Queries;
using SinteksApp.Application.Features.Bonus.Specs;
using SinteksApp.Domain.Entities;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public class PercentBonusStrategy(IRepositoryBase<EmployeeMonthlySalary> salaryRepo) 
    : IBonusCalculationStrategy
{
    public BonusType Type => BonusType.Percent;

    public async Task<decimal> CalculateAsync(BonusDefinition def, Domain.Entities.Employee employee, CalculateEmployeeBonusQuery query, decimal branchTotalSales, CancellationToken ct)
    {
        var rule = def.Rules
            .Where(x => (x.JobPositionId == null || x.JobPositionId == employee.JobPositionId) 
                        && x.BonusPercent.HasValue 
                        && x.MinSales <= branchTotalSales)
            .OrderByDescending(x => x.MinSales)
            .FirstOrDefault();

        if (rule?.BonusPercent == null) return 0m;

        var salary = await salaryRepo.FirstOrDefaultAsync(new EmployeeMonthlySalarySpec(employee.Id, employee.CurrentBranchId, query.Year, query.Month), ct);

        return (salary?.SalaryAmount ?? 0m) * (rule.BonusPercent.Value / 100m);
    }
}