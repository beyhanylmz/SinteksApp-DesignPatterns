using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class SubCompanyConfiguration : IEntityTypeConfiguration<SubCompany>
{
    public void Configure(EntityTypeBuilder<SubCompany> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(250);

        builder.HasMany(x => x.Brands)
            .WithOne()
            .HasForeignKey(b => b.SubCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.BrandAssignments)
            .WithOne(a => a.SubCompany)
            .HasForeignKey(a => a.SubCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}