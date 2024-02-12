using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Factories;

namespace VSOP.Persistence.Configuration;

internal class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
    public void Configure(EntityTypeBuilder<Factory> builder)
    {
        builder.HasOne(p => p.Region)
             .WithMany(r => r.Factories)
             .HasForeignKey(p => p.RegionId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Producers");
    }
}