using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Country>()
            .WithOne()
            .HasForeignKey(x => x.)

    }
}