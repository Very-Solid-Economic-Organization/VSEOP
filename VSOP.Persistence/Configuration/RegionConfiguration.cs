using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Regions;

namespace VSOP.Persistence.Configuration;

internal class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(r => r.Id);

        //builder.HasOne(r => r.Country)
        //    .WithMany(c => c.Regions)
        //    .HasForeignKey(c => c.CountryId)
        //    .IsRequired()
        //    .OnDelete(DeleteBehavior.Cascade);
    }
}