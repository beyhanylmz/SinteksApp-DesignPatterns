using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> b)
    {
        b.Property(x => x.FullName)
            .HasMaxLength(200).
            IsRequired();
        b.Property(x => x.CurrentBranchId)
            .IsRequired();

        b.HasMany(x => x.Transfers)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);
    }
}