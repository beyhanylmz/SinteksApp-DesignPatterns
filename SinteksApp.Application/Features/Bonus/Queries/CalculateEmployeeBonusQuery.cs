using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Application.Features.Bonus.Response;
using SinteksApp.Application.Features.Bonus.Specs;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Queries;

public record CalculateEmployeeBonusQuery(int EmployeeId, int Year, int Month ) : IRequest<Result<EmployeeBonusResponse>>;
public class CalculateEmployeeBonusQueryHandler(
    IRepositoryBase<Domain.Entities.Employee> employeeRepo,
    IRepositoryBase<EmployeeBranchTransfer> transferRepo,
    IRepositoryBase<EmployeeMonthlySales> employeeSalesRepo,
    IRepositoryBase<Domain.Entities.Sale> salesRepo,
    IRepositoryBase<BonusDefinition> bonusDefRepo,
    IBonusStrategyFactory strategyFactory
) : IRequestHandler<CalculateEmployeeBonusQuery, Result<EmployeeBonusResponse>>
{
    public async Task<Result<EmployeeBonusResponse>> Handle(CalculateEmployeeBonusQuery query, CancellationToken ct)
    {
        if (query.Month < 1 || query.Month > 12) return Result.Fail("Invalid month.");

        var employee = await employeeRepo.GetByIdAsync(query.EmployeeId, ct);
        if (employee is null)
            return Result.Fail("Employee not found.");

        // Rule: no bonus if transferred during the month
        var transferred =
            await transferRepo.AnyAsync(new TransferInRangeSpec(query.EmployeeId, query.Year, query.Month), ct);
        if (transferred)
        {
            return Result.Ok(new EmployeeBonusResponse(false, 0,
                "Not eligible: employee transferred during the month."));
        }

        // Personal sales
        var personalSales = await employeeSalesRepo.FirstOrDefaultAsync(
            new EmployeeMonthlySalesSpec(query.EmployeeId, query.Year, query.Month),
            ct);

        // BranchId for that month: use monthly sales if exists, otherwise current branch
        var branchId = personalSales?.BranchId ?? employee.CurrentBranchId;

        // Branch total sales (simple sum of employee monthly sales)
        var sales = await salesRepo.ListAsync(new BranchMonthlySalesSumSpec(branchId, query.Year, query.Month), ct);
        var branchTotalSales = sales.Sum(x => x.NetPrice);

        // Monthly active bonus definition
        var bonusDef =
            await bonusDefRepo.FirstOrDefaultAsync(new BonusDefinitionForMonthSpec(branchId, query.Year, query.Month),
                ct);

        if (bonusDef is null)
        {
            return Result.Ok(new EmployeeBonusResponse(true, 0,
                "No bonus definition configured for this branch/month."));
        }

        var strategy = strategyFactory.GetStrategy(bonusDef.Type);
        var amount = await strategy.CalculateAsync(bonusDef, employee, query, branchTotalSales, ct);

        return Result.Ok(new EmployeeBonusResponse(true, amount, null));
    }
}