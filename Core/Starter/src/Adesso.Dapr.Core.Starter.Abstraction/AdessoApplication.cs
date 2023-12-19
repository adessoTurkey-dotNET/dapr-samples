
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;

namespace Adesso.Dapr.Core.Starter.Abstraction;

public abstract class AdessoApplication : IHost, IApplicationBuilder, IEndpointRouteBuilder, IAsyncDisposable
{
    private readonly WebApplication _application;

    protected AdessoApplication(WebApplication application)
    {
        _application = application;
    }

    public void Dispose()
    {
        ((IDisposable) _application).Dispose();
    }

    public Task StartAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _application.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _application.StopAsync(cancellationToken);
    }

    public IServiceProvider Services => _application.Services;

    public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
    {
        return ((IApplicationBuilder) _application).Use(middleware);
    }

    public IApplicationBuilder New()
    {
        return ((IApplicationBuilder) _application).New();
    }

    public RequestDelegate Build()
    {
        return ((IApplicationBuilder) _application).Build();
    }

    public IServiceProvider ApplicationServices
    {
        get => ((IApplicationBuilder) _application).ApplicationServices;
        set => ((IApplicationBuilder) _application).ApplicationServices = value;
    }

    public IFeatureCollection ServerFeatures => ((IApplicationBuilder) _application).ServerFeatures;

    public IDictionary<string, object?> Properties => ((IApplicationBuilder) _application).Properties;

    public IApplicationBuilder CreateApplicationBuilder()
    {
        return ((IEndpointRouteBuilder) _application).CreateApplicationBuilder();
    }

    public IServiceProvider ServiceProvider => ((IEndpointRouteBuilder) _application).ServiceProvider;

    public ICollection<EndpointDataSource> DataSources => ((IEndpointRouteBuilder) _application).DataSources;

    public IWebHostEnvironment Environment => _application.Environment;

    public ValueTask DisposeAsync()
    {
        return _application.DisposeAsync();
    }
}