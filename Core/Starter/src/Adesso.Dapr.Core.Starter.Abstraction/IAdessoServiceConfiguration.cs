using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.Starter.Abstraction;

public interface IAdessoServiceConfiguration
{
    void Configure(IServiceCollection services, IConfiguration configuration);
}