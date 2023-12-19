using Adesso.Dapr.Core.InfoAccessor.Abstraction;
using Adesso.Dapr.Core.InfoAccessor.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.InfoAccessor.Extensions;

public static class BuilderExtensions
{
    public static IServiceCollection AddAdessoInfoAccessor(this IServiceCollection services,
        IConfiguration configuration, Action<InfoAccessorConfigurationSettings> setupAction = null)
    {
        var options = new InfoAccessorConfigurationSettings();
        setupAction?.Invoke(options);

        services.AddSingleton<AdessoInfoContainerForSigleton>();
        services.AddScoped<AdessoInfoContainerForScoped>();
        services.AddScoped<IAdessoInfoContainer, AdessoInfoContainer>();
        services.AddScoped<IAdessoInfoAccessor, AdessoInfoAccessor>();

        return services;
    }
}