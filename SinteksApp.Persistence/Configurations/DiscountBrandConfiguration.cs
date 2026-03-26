using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class DiscountBrandConfiguration : IEntityTypeConfiguration<DiscountBrand>
{
    public void Configure(EntityTypeBuilder<DiscountBrand> b)
    {
        b.ConfigureBaseEntity();
        b.Property(x => x.BrandId)
            .IsRequired();
        b.Property(x => x.DiscountId)
            .IsRequired();
    }
}