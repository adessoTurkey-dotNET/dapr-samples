using Adesso.Dapr.Core.UnitOfWork;
using Adesso.Dapr.Core.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniUow.DependencyInjection;

namespace Adesso.Core.Infrastructure.UnitOfWork.Extention;

public class AdessoUnitOfWorkOptions
{
    public bool UseMigration { get; set; } = false;
    public string MigrationAssembly { get; set; } = "";
}

public static class BuilderExtensions
{
    public static IServiceCollection AddAdessoUnitOfWork<TContext>(this IServiceCollection services,
        IConfiguration configuration,
        string dbName,
        Action<AdessoUnitOfWorkOptions> action = null)
        where TContext : DbContext
    {
        var options = new AdessoUnitOfWorkOptions();
        action?.Invoke(options);

        services.AddDbContext<TContext>(o =>
                o.UseLazyLoadingProxies()
                    .UseSqlServer(
                        configuration.GetConnectionString(dbName),
                        builder =>
                        {
                            builder.CommandTimeout(60);
                            if (options.UseMigration)
                                builder.MigrationsAssembly(options.MigrationAssembly);
                        })
                    .ConfigureWarnings(warning => warning.Ignore(CoreEventId.DetachedLazyLoadingWarning))
            // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        ).AddUnitOfWork<TContext>();
        services.AddScoped<IAdessoUnitOfWork, AdessoUnitOfWork<TContext>>();
        services.AddScoped<IAdessoUnitOfWork<TContext>, AdessoUnitOfWork<TContext>>();
        services.Scan(scanner =>
        {
            scanner.AddTypes(typeof(AdessoUnitOfWork<>))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });

        return services;
    }
}