using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Models.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class RegionConfigurattion : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(x => x.Id);

    }
}