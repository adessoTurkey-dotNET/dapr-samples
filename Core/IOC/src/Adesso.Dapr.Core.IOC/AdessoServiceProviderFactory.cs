using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.IOC;

internal sealed class AdessoServiceProviderFactory : IServiceProviderFactory<ContainerBuilder>
{
    private readonly AutofacServiceProviderFactory _autofacServiceProviderFactory;

    public AdessoServiceProviderFactory()
    {
        this._autofacServiceProviderFactory = new AutofacServiceProviderFactory();
    }

    public ContainerBuilder CreateBuilder(IServiceCollection services)
    {
        var builder = this._autofacServiceProviderFactory.CreateBuilder(services);

        return builder;
    }

    public IServiceProvider CreateServiceProvider(ContainerBuilder containerBuilder)
    {
        return new AdessoServiceProvider(this._autofacServiceProviderFactory.CreateServiceProvider(containerBuilder));
    }
}