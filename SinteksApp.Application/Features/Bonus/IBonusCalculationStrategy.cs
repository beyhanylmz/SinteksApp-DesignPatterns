using SinteksApp.Application.Features.Bonus.Queries;
using SinteksApp.Domain.Entities;
using SinteksApp.Domain.Enums;

namespace SinteksApp.Application.Features.Bonus;

public interface IBonusCalculationStrategy
{
    BonusType Type { get; }
    Task<decimal> CalculateAsync(BonusDefinition def, Domain.Entities.Employee employee, CalculateEmployeeBonusQuery query, decimal branchTotalSales, CancellationToken ct);
}