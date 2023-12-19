using System.Reflection;
using FluentValidation;
using LinqKit;
using MediatR;
using MediatR.Pipeline;
using Adesso.Dapr.Core.Common.Abstraction.Exception;
using Adesso.Dapr.Core.Common.Abstraction.Helpers;
using Adesso.Dapr.Core.CQRS;
using Adesso.Dapr.Core.CQRS.Abstraction;
using Adesso.Dapr.Core.CQRS.Abstraction.Handler;
using Adesso.Dapr.Core.CQRS.Decorator;
using Adesso.Dapr.Core.CQRS.Pipeline;
using Adesso.Dapr.Core.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.Infrastructure.CQRS.Extention;

public static class BuilderExtensions
{
    public static IServiceCollection AddAdessoCQRS(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(services.GetType().Assembly);
        services.AddScoped<IAdessoCQRSProcessor, AdessoCQRSProcessor>();

        var applicationAssemblies = AdessoModuleAssemblyDiscovery.GetInstance().ApplicationAssemblies;

        services.Scan(scan => scan.FromAssemblies(applicationAssemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IAdessoRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblies(applicationAssemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IAdessoQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan.FromAssemblies(applicationAssemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IAdessoCommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddScoped(typeof(IRequestPreProcessor<>), typeof(AdessoValidationRequestPreProcessor<>));
        services.TryDecorate(typeof(IRequestHandler<,>), typeof(AdessoQueryHandlerDecorator<,>));
        services.TryDecorate(typeof(IRequestHandler<,>), typeof(AdessoCommandHandlerDecorator<,>));

        return services;
    }
}