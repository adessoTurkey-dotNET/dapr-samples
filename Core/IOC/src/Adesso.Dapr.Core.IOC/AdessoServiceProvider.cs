namespace Adesso.Dapr.Core.IOC;

internal sealed class AdessoServiceProvider : IServiceProvider
{
    private readonly IServiceProvider _serviceProviderImplementation;

    public AdessoServiceProvider(IServiceProvider serviceProviderImplementation)
    {
        _serviceProviderImplementation = serviceProviderImplementation;
    }

    public object? GetService(Type serviceType)
    {
        return this._serviceProviderImplementation.GetService(serviceType);
    }
}