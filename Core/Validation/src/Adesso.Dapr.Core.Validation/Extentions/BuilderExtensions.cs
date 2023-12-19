using FluentValidation;
using Adesso.Dapr.Core.Common.Abstraction.Helpers;
using Adesso.Dapr.Core.Validation.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.Validation.Extention;

public static class BuilderExtensions
{
    public static IServiceCollection AddAdessoValidation(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(scanner =>
        {
            var openHandlerTypes = new[]
            {
                typeof(IValidator<>),
            };
            foreach (var openHandlerType in openHandlerTypes)
            {
                scanner
                    .FromAssemblies(AdessoModuleAssemblyDiscovery.GetInstance().ApplicationAssemblies)
                    .AddClasses(classes => classes.AssignableTo(openHandlerType))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            }
        });

        return services;
    }
}