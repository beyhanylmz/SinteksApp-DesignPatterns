using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinteksApp.Domain.Entities;
using Quartz;
using SinteksApp.Persistence.Context;

namespace SinteksApp.Infrastructure.Jobs;

[DisallowConcurrentExecution]
public class EmployeeMonthlySalesJob(SinteksAppDbContext dbContext) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var now = DateTime.UtcNow;

        var targetDate = new DateTime(now.Year, now.Month, 1).AddMonths(-1);
        var year = targetDate.Year;
        var month = targetDate.Month;

        var monthlySales = await dbContext.Sales
            .Where(x => x.SaleDate.Year == year && x.SaleDate.Month == month)
            .GroupBy(x => new { x.EmployeeId, x.BranchId })
            .Select(g => new EmployeeMonthlySales
            {
                EmployeeId = g.Key.EmployeeId,
                BranchId = g.Key.BranchId,
                Year = year,
                Month = month,
                TotalSalesCount = g.Count(x => !x.IsReturned),
                TotalNetSalesAmount = g.Where(x => !x.IsReturned).Sum(x => x.NetPrice),
                ReturnedSalesCount = g.Count(x => x.IsReturned),
                ReturnedSalesAmount = g.Where(x => x.IsReturned).Sum(x => x.NetPrice)
            })
            .ToListAsync(context.CancellationToken);

        var existingRows = await dbContext.EmployeeMonthlySales
            .Where(x => x.Year == year && x.Month == month)
            .ToListAsync(context.CancellationToken);

        if (existingRows.Count > 0)
            dbContext.EmployeeMonthlySales.RemoveRange(existingRows);

        if (monthlySales.Count > 0)
            await dbContext.EmployeeMonthlySales.AddRangeAsync(monthlySales, context.CancellationToken);

        await dbContext.SaveChangesAsync(context.CancellationToken);
    }
}