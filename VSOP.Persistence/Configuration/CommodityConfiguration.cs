using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class CommodityConfiguration : IEntityTypeConfiguration<Commodity>
{
    public void Configure(EntityTypeBuilder<Commodity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.World)
            .WithMany(w => w.Commodities)
            .HasForeignKey(c => c.WorldId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<ProcessedCommodity>()
            .WithOne(x => x.Commodity)
            .HasForeignKey(x => x.CommodityId);

        builder.HasMany<StoredCommodity>()
            .WithOne(x => x.Commodity)
            .HasForeignKey(x => x.CommodityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
