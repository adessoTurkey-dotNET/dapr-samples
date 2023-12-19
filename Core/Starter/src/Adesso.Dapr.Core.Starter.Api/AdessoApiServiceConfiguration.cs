

using Adesso.Dapr.Core.Starter.Abstraction;
using Adesso.Dapr.Core.IOC.Extention;
using Adesso.Dapr.Core.Configuration;
using Adesso.Dapr.Core.InfoAccessor.Extensions;
using Adesso.Dapr.Core.Infrastructure.CQRS.Extention;
using Adesso.Dapr.Core.Validation.Extention;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Adesso.Dapr.Core.InfoAccessor.Abstraction;

namespace Adesso.Dapr.Core.Starter.Api;

public class AdessoApiServiceConfiguration : IAdessoServiceConfiguration
{
    public AdessoAppInfo AppInfo { get; }

    public AdessoApiServiceConfiguration(AdessoAppInfo appInfo)
    {
        AppInfo = appInfo;
    }
    
    public void Configure(IServiceCollection services, IConfiguration configuration)
    {
        AdessoConfiguration.Configuration = configuration;
        services.AddHttpContextAccessor();
        services.AddAdessoApi(configuration);
        services.AddAdessoIOC(configuration);
        services.AddAdessoCQRS(configuration);
        services.AddAdessoValidation(configuration);
        services.AddAdessoInfoAccessor(configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}