using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class BranchMonthlySalesLimitConfiguration : IEntityTypeConfiguration<BranchMonthlySalesLimit>
{
    public void Configure(EntityTypeBuilder<BranchMonthlySalesLimit> b)
    {
        b.ConfigureBaseEntity();
        
        b.Property(x => x.LimitAmount)
            .HasColumnType("decimal(18,2)");
    }
}