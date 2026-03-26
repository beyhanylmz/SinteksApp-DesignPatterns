using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinteksApp.Domain.Entities;

namespace SinteksApp.Persistence.Configurations;

public class BrandSubCompanyAssignmentConfiguration : IEntityTypeConfiguration<BrandSubCompanyAssignment>
{
    public void Configure(EntityTypeBuilder<BrandSubCompanyAssignment> b)
    {
        b.Property(x => x.StartDateUtc).IsRequired();
        b.Property(x => x.Note).HasMaxLength(500);
        b.Property(x => x.ChangedBy).HasMaxLength(200);

    }
}