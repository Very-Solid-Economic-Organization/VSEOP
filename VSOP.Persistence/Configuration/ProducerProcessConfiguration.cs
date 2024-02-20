using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence.Configuration;

internal class ProducerProcessConfiguration : IEntityTypeConfiguration<ProducerProcess>
{
    public void Configure(EntityTypeBuilder<ProducerProcess> builder)
    {
        builder.HasKey(pp => pp.Id);

        builder.HasOne(pp => pp.Producer)
            .WithMany(p => p.Processes)
            .HasForeignKey(pp => pp.ProducerId);

        builder.HasOne(pp => pp.Process)
            .WithMany()
            .IsRequired()
            .HasForeignKey(pp => pp.ProcessId);
    }
}