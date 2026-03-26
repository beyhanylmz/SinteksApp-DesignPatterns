using Ardalis.Specification;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Employee.Commands;

public class TransferExistsOnDateSpec : Specification<EmployeeBranchTransfer>
{
    public TransferExistsOnDateSpec(int employeeId, DateTime date)
    {
        Query.Where(x => x.EmployeeId == employeeId && x.TransferDate.Date == date.Date);
    }
}