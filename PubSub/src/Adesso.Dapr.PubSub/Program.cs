using Adesso.Dapr.Core.InfoAccessor.Abstraction;
using Adesso.Dapr.Core.Starter;

var builder = AdessoApplicationBuilder.CreateBuilder(new AdessoAppInfo
{
    Name = "Dapr.PubSub",
    Type = AppType.Api
}, args);

builder.Services.AddControllers().AddDapr();

var app = builder.Build();
app.Run();