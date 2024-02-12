using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Configuration;

internal class ProcessConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(p => p.ProcessedCommodities)
            .WithOne(pc => pc.Process)
            .HasForeignKey(p => p.ProcessId);

        #region Сомнительно, но Okay
        builder.Ignore(x => x.CosumedCommdities); 
        builder.Ignore(x => x.ProducedCommdities);
        #endregion
    }
}