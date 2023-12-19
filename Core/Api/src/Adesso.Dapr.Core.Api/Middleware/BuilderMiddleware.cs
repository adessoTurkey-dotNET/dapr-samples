using System.Diagnostics;
using System.Text.Json;
using Adesso.Dapr.Core.Infrastructure.Api;
using Adesso.Dapr.Core.Infrastructure.Exception;
using Adesso.Dapr.Core.Infrastructure.Exception.Middleware;
using Adesso.Dapr.Core.Common.Abstraction.Exception;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Adesso.Core.Infrastructure.Exception;

namespace Adesso.Dapr.Core.Api.Middleware
{
    public static class BuilderMiddleware
    {
        public static void UseAdessoGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var activity = Activity.Current.Start();
                    activity.SetStatus(ActivityStatusCode.Error, exceptionFeature.Error.ToString());

                    var statusCode = exceptionFeature.Error switch
                    {
                        AdessoBusinessException => 400,
                        _ => 500
                    };

                    var response =
                        new AdessoApiResponse<NoContext>(AdessoResponseHeader.Fail(exceptionFeature.Error), null);
                    if (exceptionFeature.Error is AdessoException)
                    {
                        var AdessoEx = (AdessoException) exceptionFeature.Error;
                        response.Header.ErrorMessage = AdessoEx.Message;
                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    var jsonString = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });

                    await context.Response.WriteAsync(jsonString);
                });
            });
        }
    }
}