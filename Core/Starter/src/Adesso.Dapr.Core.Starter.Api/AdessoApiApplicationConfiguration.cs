using Adesso.Dapr.Core.Api.Middleware;
using Adesso.Dapr.Core.Starter.Abstraction;
using Adesso.Dapr.Core.Starter.Abstraction.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Adesso.Dapr.Core.Starter.Api;

public class AdessoApiApplicationConfiguration : IAdessoApplicationConfiguration
{
    public void Configure(AdessoApplication app, IWebHostEnvironment env)
    {
        app.UseMiddleware<AdessoRequestResponseMiddleware>();
        app.UseMiddleware<AdessoInfoMiddleware>();
        app.UseAdessoGlobalExceptionMiddleware();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}