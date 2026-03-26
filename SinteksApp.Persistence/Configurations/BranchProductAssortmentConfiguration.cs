using SinteksApp.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Persistence.Configurations;

public class BranchProductAssortmentConfiguration : IEntityTypeConfiguration<BranchProductAssortment>
{
    public void Configure(EntityTypeBuilder<BranchProductAssortment> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(x => x.IsAvailable)
            .IsRequired();
        
        builder.HasOne(x => x.Branch)
            .WithMany(x => x.BranchProductAssortments)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.BranchProductAssortments)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}