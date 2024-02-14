using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Enums;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class StoredCommodityConfiguration : IEntityTypeConfiguration<StoredCommodity>
{
    public void Configure(EntityTypeBuilder<StoredCommodity> builder)
    {
        builder.HasKey(sc => sc.Id);

       builder.HasOne<Commodity>()
            .WithMany()
            .HasForeignKey(sc => sc.CommodityId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.Property(x => x.CurrentDemand).HasConversion(c => c.ToString(), c => Enum.Parse<Demand>(c));           
    }
}
