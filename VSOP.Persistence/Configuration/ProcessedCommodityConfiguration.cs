using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Configuration;

internal class ProcessedCommodityConfiguration : IEntityTypeConfiguration<ProcessedCommodity>
{
    public void Configure(EntityTypeBuilder<ProcessedCommodity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Process)
            .WithMany(x => x.ProcessedCommodities)
            .HasForeignKey(x => x.ProcessId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}