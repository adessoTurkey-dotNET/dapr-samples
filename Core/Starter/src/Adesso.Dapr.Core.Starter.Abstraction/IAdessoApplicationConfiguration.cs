using Microsoft.AspNetCore.Hosting;

namespace Adesso.Dapr.Core.Starter.Abstraction;

public interface IAdessoApplicationConfiguration
{
    void Configure(AdessoApplication app, IWebHostEnvironment env);
}