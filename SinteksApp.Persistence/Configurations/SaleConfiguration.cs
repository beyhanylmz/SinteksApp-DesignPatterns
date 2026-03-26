using SinteksApp.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Persistence.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ConfigureBaseEntity();

        builder.Property(x => x.Quantity)
            .IsRequired();  
        
        builder.Property(x => x.BasePrice)
            .IsRequired();  
        builder.Property(x => x.DiscountedPrice)
            .IsRequired();  
        builder.Property(x => x.DiscountPercent)
            .IsRequired();  

        builder.Property(x => x.EmployeeId)
            .IsRequired();  
        
        builder.Property(x => x.SaleDate)
            .IsRequired();  
        
        builder.HasOne(x => x.Branch)
            .WithMany(x => x.Sales)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);    
        
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Sales)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}