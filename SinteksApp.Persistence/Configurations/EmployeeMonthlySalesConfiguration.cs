using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class EmployeeMonthlySalesConfiguration : IEntityTypeConfiguration<EmployeeMonthlySales>
{
    public void Configure(EntityTypeBuilder<EmployeeMonthlySales> b)
    {
        b.ConfigureBaseEntity();
        
        b.Property(x => x.TotalNetSalesAmount)
            .HasColumnType("decimal(18,2)");
    }
}