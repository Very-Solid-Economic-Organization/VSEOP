using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Configuration;

internal class ProcessedCommodityConfiguration : IEntityTypeConfiguration<ProcessedCommodity>
{
    public void Configure(EntityTypeBuilder<ProcessedCommodity> builder)
    {
        builder.HasKey(pc => pc.Id);

        builder.HasOne(pc => pc.Process)
            .WithMany(p => p.ProcessedCommodities)
            .HasForeignKey(pc => pc.ProcessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}