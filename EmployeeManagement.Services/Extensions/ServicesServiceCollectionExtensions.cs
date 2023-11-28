using EmployeeManagement.Domain.Interfaces.Services;
using EmployeeManagement.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Services.Extensions;

public static class ServicesServiceCollectionExtensions
{
    public static IServiceCollection AddServicesServices(this IServiceCollection services)
    {
        services.AddScoped<IElasticSearchService, ElasticSearchService>();
        services.AddScoped<IKafkaService, KafkaService>();
        services.AddScoped<IPermissionsService, PermissionsService>();

        return services;
    }
}