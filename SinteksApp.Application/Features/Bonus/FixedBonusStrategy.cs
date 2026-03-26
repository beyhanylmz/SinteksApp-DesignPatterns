using Ardalis.Specification;
using SinteksApp.Application.Features.Bonus.Queries;
using SinteksApp.Application.Features.Bonus.Specs;
using SinteksApp.Domain.Entities;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public class FixedBonusStrategy(IRepositoryBase<EmployeeMonthlySales> employeeSalesRepo) 
    : IBonusCalculationStrategy
{
    public BonusType Type => BonusType.Fixed;

    public async Task<decimal> CalculateAsync(BonusDefinition def, Domain.Entities.Employee employee, CalculateEmployeeBonusQuery query, decimal branchTotalSales, CancellationToken ct)
    {
        var personalSales = await employeeSalesRepo.FirstOrDefaultAsync(new EmployeeMonthlySalesSpec(employee.Id, query.Year, query.Month), ct);
        
        var personalSalesTotal = personalSales?.TotalNetSalesAmount ?? 0m;

        var rule = def.Rules
            .Where(x => (x.JobPositionId == null || x.JobPositionId == employee.JobPositionId) 
                        && x.BonusAmount.HasValue 
                        && x.MinSales <= personalSalesTotal)
            .OrderByDescending(x => x.MinSales)
            .FirstOrDefault();

        return rule?.BonusAmount ?? 0m;
    }
}