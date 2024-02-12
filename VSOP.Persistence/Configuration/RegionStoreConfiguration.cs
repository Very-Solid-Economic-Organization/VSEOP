using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class RegionStoreConfiguration : IEntityTypeConfiguration<RegionStore>
{
    public void Configure(EntityTypeBuilder<RegionStore> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Region)
            .WithOne(x => x.RegionStore)
            .HasForeignKey<RegionStore>(x => x.RegionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}