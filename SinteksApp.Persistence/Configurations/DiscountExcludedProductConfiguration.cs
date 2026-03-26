using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class DiscountExcludedProductConfiguration : IEntityTypeConfiguration<DiscountExcludedProduct>
{
    public void Configure(EntityTypeBuilder<DiscountExcludedProduct> b)
    {
        b.ConfigureBaseEntity();
    }
}