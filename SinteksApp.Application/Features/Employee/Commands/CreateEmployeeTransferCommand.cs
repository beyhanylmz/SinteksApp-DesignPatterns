using Ardalis.Specification;
using FluentResults;
using MediatR;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Application.Features.Employee.Commands;

public record CreateEmployeeTransferCommand(
    int EmployeeId,
    int NewBranchId,
    DateTime TransferDateUtc
) : IRequest<Result<int>>;

public class CreateEmployeeTransferCommandHandler(
    IRepositoryBase<Domain.Entities.Employee> employeeRepo,
    IRepositoryBase<EmployeeBranchTransfer> transferRepo
) : IRequestHandler<CreateEmployeeTransferCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateEmployeeTransferCommand r, CancellationToken ct)
    {
        var employee = await employeeRepo.GetByIdAsync(r.EmployeeId, ct);
        if (employee is null)
            return Result.Fail("Employee not found.");

        if (employee.CurrentBranchId == r.NewBranchId)
            return Result.Fail("NewBranchId must be different than current branch.");

        // Prevent multiple transfers on same day (simple guard)
        var anySameDay = await transferRepo.AnyAsync(
            new TransferExistsOnDateSpec(r.EmployeeId, r.TransferDateUtc.Date),
            ct);

        if (anySameDay)
            return Result.Fail("Employee already has a transfer on that date.");

        var transfer = new EmployeeBranchTransfer
        {
            EmployeeId = employee.Id,
            OldBranchId = employee.CurrentBranchId,
            NewBranchId = r.NewBranchId,
            TransferDate = r.TransferDateUtc
        };

        // Update current branch
        employee.CurrentBranchId = r.NewBranchId;

        await transferRepo.AddAsync(transfer, ct);
        await employeeRepo.UpdateAsync(employee, ct);
        
        await transferRepo.SaveChangesAsync(ct);

        return Result.Ok(transfer.Id);
    }
}