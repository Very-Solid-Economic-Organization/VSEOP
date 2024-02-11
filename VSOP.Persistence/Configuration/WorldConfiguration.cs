using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
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