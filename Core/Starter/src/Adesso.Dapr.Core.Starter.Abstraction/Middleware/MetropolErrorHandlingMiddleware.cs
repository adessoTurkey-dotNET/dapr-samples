using System.Net;
using System.Text.Json;
using Adesso.Dapr.Core.Infrastructure.Api;
using Adesso.Dapr.Core.Infrastructure.Exception.Middleware;
using Microsoft.AspNetCore.Http;


namespace Adesso.Dapr.Core.Starter.Abstraction.Middleware
{
    public class AdessoErrorHandlingMiddleware
    {
         private readonly RequestDelegate _next;

    public AdessoErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var header = AdessoResponseHeader.Fail(ex);
            var response = new AdessoApiResponse<NoContext>(header, new NoContext());
            var camelCaseJsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, camelCaseJsonSerializerOptions));

        }
    }
    }
}