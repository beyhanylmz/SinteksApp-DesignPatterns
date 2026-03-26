using Ardalis.Specification;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class AllEmployeesInBranchMonthSpec : Specification<Domain.Entities.Employee>
{
    public AllEmployeesInBranchMonthSpec(int branchId, int year, int month)
    {
        var monthStart = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
        var monthEnd = monthStart.AddMonths(1).AddTicks(-1);

        Query.Where(x => x.CurrentBranchId == branchId &&
            !x.Transfers.Any(t =>
                t.TransferDate >= monthStart &&
                t.TransferDate <= monthEnd));
    }
}