using Microsoft.EntityFrameworkCore;
using VSOP.Domain.DbModels.Producers;

namespace VSOP.Persistence;

internal class VSEOPContext : DbContext
{
    public VSEOPContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VSEOPContext).Assembly);
    }
}