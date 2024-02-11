using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Models.DbModels.Countries;

namespace VSOP.Persistence.Configuration;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(w => w.Id);

        builder.HasMany(w => w.Regions)
            .WithOne()
            .HasForeignKey(c => c.CountryId);
    }
}