using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Commodities;

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
    }
}
