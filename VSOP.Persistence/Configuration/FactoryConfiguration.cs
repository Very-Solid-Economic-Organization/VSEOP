using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSOP.Domain.DbModels.Factories;

namespace VSOP.Persistence.Configuration;

internal class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
    public void Configure(EntityTypeBuilder<Factory> builder)
    {

        builder.ToTable("Producers");
    }
}