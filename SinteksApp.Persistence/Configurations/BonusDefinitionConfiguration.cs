using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class BonusDefinitionConfiguration : IEntityTypeConfiguration<BonusDefinition>
{
    public void Configure(EntityTypeBuilder<BonusDefinition> b)
    {
        b.ConfigureBaseEntity();

        b.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();
        b.Property(x => x.Type)
            .IsRequired();

        b.HasMany(x => x.Rules)
            .WithOne(x => x.BonusDefinition)
            .HasForeignKey(x => x.BonusDefinitionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}