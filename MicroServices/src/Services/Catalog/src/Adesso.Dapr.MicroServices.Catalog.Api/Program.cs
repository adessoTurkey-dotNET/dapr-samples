using Adesso.Dapr.Core.InfoAccessor.Abstraction;
using Adesso.Dapr.Core.Starter;

var builder = AdessoApplicationBuilder.CreateBuilder(new AdessoAppInfo
{
    Name = "Catalog",
    Type = AppType.Api
}, args);

var app = builder.Build();

app.Run();