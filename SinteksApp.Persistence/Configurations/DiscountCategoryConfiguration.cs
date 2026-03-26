using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class DiscountCategoryConfiguration : IEntityTypeConfiguration<DiscountCategory>
{
    public void Configure(EntityTypeBuilder<DiscountCategory> b)
    {
        b.ConfigureBaseEntity();
        b.Property(x => x.CategoryId)
            .IsRequired();
        b.Property(x => x.DiscountId)
            .IsRequired();
    }
}