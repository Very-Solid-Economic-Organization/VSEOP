using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Country)
            .WithMany()
            .HasForeignKey(r => r.CountryId);

        builder.HasMany(r => r.Producers)
            .WithOne()
            .HasForeignKey(r => r.RegionId);
    }
}