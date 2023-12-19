using Adesso.Dapr.Core.Starter.Abstraction;
using Adesso.Dapr.Core.Starter.Api;
using  Adesso.Dapr.Core.InfoAccessor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Adesso.Dapr.Core.InfoAccessor.Abstraction;

namespace Adesso.Dapr.Core.Starter;

public class AdessoApplicationBuilder
{
    private readonly WebApplicationBuilder _builder;

    public IWebHostEnvironment Environment => _builder.Environment;

    public IServiceCollection Services => _builder.Services;

    public ConfigurationManager Configuration => _builder.Configuration;

    public ILoggingBuilder Logging => _builder.Logging;

    public ConfigureWebHostBuilder WebHost => _builder.WebHost;

    public ConfigureHostBuilder Host => _builder.Host;

    public AdessoAppInfo AppInfo { get; set; }


    private AdessoApplicationBuilder(AdessoAppInfo appInfo, string[] args)
    {
        AppInfo = appInfo;
        _builder = WebApplication.CreateBuilder(args);
    }

    public static AdessoApplicationBuilder CreateBuilder(AdessoAppInfo appInfo, string[] args = null)
    {
        return new AdessoApplicationBuilder(appInfo, args);
    }

    public AdessoApplication Build()
    {
        switch (AppInfo.Type)
        {
            case AppType.Api:
                return BuildForApi();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private AdessoApplication BuildForApi()
    {
        var serviceConfiguration = new AdessoApiServiceConfiguration(AppInfo);
        serviceConfiguration.Configure(_builder.Services, _builder.Configuration);

        var application = new AdessoApiApplication(_builder.Build());

        var infoContainer = application.Services.GetRequiredService<AdessoInfoContainerForSigleton>();
        infoContainer.Set(AppInfo);

        var applicationConfiguration = new AdessoApiApplicationConfiguration();
        applicationConfiguration.Configure(application, application.Environment);

        return application;
    }

}