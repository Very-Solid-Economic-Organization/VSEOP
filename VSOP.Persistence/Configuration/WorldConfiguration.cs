using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Models.DbModels.Regions;
using VSOP.Models.DbModels.Worlds;
namespace VSOP.Persistence.Configuration;

internal class WorldConfiguration : IEntityTypeConfiguration<World>
{
    public void Configure(EntityTypeBuilder<World> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasMany(w => w.Countries)
            .WithOne()
            .HasForeignKey(c => c.WorldId);
    }
}