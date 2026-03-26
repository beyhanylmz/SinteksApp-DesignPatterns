using SinteksApp.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Persistence.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Quantity)
            .IsRequired();  

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);    
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Stocks)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}