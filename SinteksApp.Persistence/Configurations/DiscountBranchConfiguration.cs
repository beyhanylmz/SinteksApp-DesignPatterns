using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;
using SinteksApp.Persistence.Extensions;

namespace SinteksApp.Persistence.Configurations;

public class DiscountBranchConfiguration : IEntityTypeConfiguration<DiscountBranch>
{
    public void Configure(EntityTypeBuilder<DiscountBranch> b)
    {
        b.ConfigureBaseEntity();
        b.Property(x => x.BranchId)
            .IsRequired();
        b.Property(x => x.DiscountId)
            .IsRequired();
    }
}