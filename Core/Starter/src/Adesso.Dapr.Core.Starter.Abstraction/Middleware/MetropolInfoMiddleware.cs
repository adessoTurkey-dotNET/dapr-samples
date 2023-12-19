using Adesso.Dapr.Core.InfoAccessor.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Adesso.Dapr.Core.Starter.Abstraction.Middleware;

public class AdessoInfoMiddleware
{
    private readonly RequestDelegate _next;

    public AdessoInfoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/info")
        {
            var infoAccessor = context.RequestServices.GetRequiredService<IAdessoInfoAccessor>();
            var info = new
            {
                infoAccessor.AppInfoAccessor.AppInfo
            };

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new StringEnumConverter());
            var json = JsonConvert.SerializeObject(info, Formatting.Indented, jsonSettings);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
        else
        {
            await _next(context);
        }
    }
}