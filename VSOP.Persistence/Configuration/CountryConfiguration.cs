using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Countries;

namespace VSOP.Persistence.Configuration;

internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.World)
            .WithMany(r => r.Countries)
            .HasForeignKey(r => r.WorldId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}