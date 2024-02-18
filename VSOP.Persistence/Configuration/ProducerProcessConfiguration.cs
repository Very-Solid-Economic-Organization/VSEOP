using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Configuration;

internal class ProducerProcessConfiguration : IEntityTypeConfiguration<ProducerProcess>
{
    public void Configure(EntityTypeBuilder<ProducerProcess> builder)
    {
        builder.HasKey(pp => new { pp.ProcessId, pp.ProducerId });

        builder.HasOne(pp => pp.Producer)
            .WithMany(p => p.ProducerProcesses)
            .HasForeignKey(pp => pp.ProducerId);

        //builder.HasOne(pp => pp.Process)
        //    .WithMany(s => s.ProducerProcesses)
        //    .HasForeignKey(sc => sc.ProcessId);
    }
}