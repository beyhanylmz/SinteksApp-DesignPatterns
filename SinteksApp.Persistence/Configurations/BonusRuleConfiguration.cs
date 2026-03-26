using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class BonusRuleConfiguration : IEntityTypeConfiguration<BonusRule>
{
    public void Configure(EntityTypeBuilder<BonusRule> b)
    {
        b.ConfigureBaseEntity();
        
        b.Property(x => x.MinSales)
            .HasColumnType("decimal(18,2)");
        b.Property(x => x.BonusAmount)
            .HasColumnType("decimal(18,2)");
        b.Property(x => x.BonusPercent)
            .HasColumnType("decimal(5,2)");
    }
}