using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class EmployeeBranchTransferConfiguration : IEntityTypeConfiguration<EmployeeBranchTransfer>
{
    public void Configure(EntityTypeBuilder<EmployeeBranchTransfer> b)
    {
        b.ConfigureBaseEntity();
        b.Property(x => x.TransferDate).
            IsRequired();
    }
}