using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Bonus.Specs;

public class TransferInRangeSpec : Specification<EmployeeBranchTransfer>
{
    public TransferInRangeSpec(int employeeId, int year , int month)
    { 
        var start = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
        var end = start.AddMonths(1).AddTicks(-1);
        Query.Where(x => x.EmployeeId == employeeId && x.TransferDate >= start && x.TransferDate <= end);
    }
}