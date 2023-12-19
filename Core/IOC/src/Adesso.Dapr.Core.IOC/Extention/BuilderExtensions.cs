using Adesso.Dapr.Core.Common.Abstraction.Exception;
using Adesso.Dapr.Core.Common.Abstraction.Helpers;
using Adesso.Dapr.Core.IOC.Abstraction.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.IOC.Extention;

public static class BuilderExtensions
{
    public static IServiceCollection AddAdessoIOC(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null)
        {
            throw new AdessoException($"ServiceCollection: {nameof(services)} not found.");
        }

        var moduleDiscovery = AdessoModuleAssemblyDiscovery.GetInstance();
        services.Scan(scan => scan.FromAssemblies(moduleDiscovery.ApplicationAssemblies)
            .AddClasses(x => x.AssignableTo(typeof(IAdessoServiceScope)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblies(moduleDiscovery.ApplicationAssemblies)
            .AddClasses(x => x.AssignableTo(typeof(IAdessoServiceTransient)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithTransientLifetime());

        services.Scan(scan => scan.FromAssemblies(moduleDiscovery.ApplicationAssemblies)
            .AddClasses(x => x.AssignableTo(typeof(IAdessoServiceSingleton)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithSingletonLifetime());
        
        services.Scan(scan => scan.FromAssemblies(moduleDiscovery.RepositoryAssemblies)
            .AddClasses(x => x.AssignableTo(typeof(IAdessoServiceScope)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblies(moduleDiscovery.RepositoryAssemblies)
            .AddClasses(x => x.AssignableTo(typeof(IAdessoServiceTransient)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithTransientLifetime());

        services.Scan(scan => scan.FromAssemblies(moduleDiscovery.RepositoryAssemblies)
            .AddClasses(x => x.AssignableTo(typeof(IAdessoServiceSingleton)))
            .AsImplementedInterfaces()
            .AsSelf()
            .WithSingletonLifetime());

        return services;
    }
}