﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSOP.Application.Data;
using VSOP.Domain.DbModels.Commodities;
using VSOP.Domain.DbModels.Countries;
using VSOP.Domain.DbModels.Factories;
using VSOP.Domain.DbModels.Producers;
using VSOP.Domain.DbModels.Regions;
using VSOP.Domain.DbModels.Worlds;
using VSOP.Persistence.Repositories;

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
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IWorldRepository, WorldRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<IRegionStoreRepository, RegionStoreRepository>();
        services.AddScoped<ICommodityRepository, CommodityRepository>();
        services.AddScoped<IStoredCommodityRepository, StoredCommodityRepository>();
        services.AddScoped<IFactoryRepository, FactoryRepository>();
        services.AddScoped<IProcessRepository, ProcessRepository>();
        services.AddScoped<IProducerRepository, ProducerRepository>();
        services.AddScoped<IProcessedCommodityRepository, ProcessedCommodityRepository>();
        services.AddScoped<IProducerProcessRepository, ProducerProcessRepository>();
        #endregion

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}