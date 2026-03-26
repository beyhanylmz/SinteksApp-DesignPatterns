using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class DiscountProductConfiguration : IEntityTypeConfiguration<DiscountProduct>
{
    public void Configure(EntityTypeBuilder<DiscountProduct> b)
    {
        b.ConfigureBaseEntity();
        b.Property(x => x.ProductId)
            .IsRequired();
        b.Property(x => x.DiscountId)
            .IsRequired();
    }
}