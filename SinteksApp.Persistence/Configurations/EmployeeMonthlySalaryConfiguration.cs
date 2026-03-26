using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class EmployeeMonthlySalaryConfiguration : IEntityTypeConfiguration<EmployeeMonthlySalary>
{
    public void Configure(EntityTypeBuilder<EmployeeMonthlySalary> b)
    {
        b.ConfigureBaseEntity();
        
        b.Property(x => x.SalaryAmount)
            .HasColumnType("decimal(18,2)");
    }
}