using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Configuration;

internal class ProducerConfiguration : IEntityTypeConfiguration<Producer>
{
    public void Configure(EntityTypeBuilder<Producer> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Region)
            .WithMany(r => r.Producers)
            .HasForeignKey(p => p.RegionId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasMany(x => x.Processes)
        //    .WithMany(x => x.Producers);

        builder.Ignore(x => x.Processes);

        builder.ToTable("Producers");
    }
}