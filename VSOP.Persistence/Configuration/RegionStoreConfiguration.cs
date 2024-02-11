using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class RegionStoreConfiguration : IEntityTypeConfiguration<RegionStore>
{
    public void Configure(EntityTypeBuilder<RegionStore> builder)
    {
        builder.HasKey(rs => rs.Id);

        builder.HasMany(sc => sc.StoredCommodities)
            .WithOne()
            .HasForeignKey(sc => sc.CommodityId);
    }
}
