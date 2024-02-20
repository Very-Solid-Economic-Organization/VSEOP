using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Regions.RegionStores;

namespace VSOP.Persistence.Configuration;

internal class RegionStoreConfiguration : IEntityTypeConfiguration<RegionStore>
{
    public void Configure(EntityTypeBuilder<RegionStore> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Region>()
            .WithOne(x => x.RegionStore)
            .HasForeignKey<RegionStore>(x => x.RegionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}