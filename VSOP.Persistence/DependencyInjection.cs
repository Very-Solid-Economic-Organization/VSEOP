using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VSOP.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
                this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<VSEOPContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        #region Repositories
        #endregion

        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}