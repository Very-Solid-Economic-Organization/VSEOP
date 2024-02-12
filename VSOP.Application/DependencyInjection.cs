using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VSOP.Application.Common.Behaviors;

namespace VSOP.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
                this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(DependencyInjection).Assembly; //Пока так
        services.AddMediatR(configuration =>
        configuration.RegisterServicesFromAssembly(assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);
        return services;
    }
}