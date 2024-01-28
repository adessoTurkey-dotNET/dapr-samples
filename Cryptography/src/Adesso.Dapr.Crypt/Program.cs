using Adesso.Dapr.Core.InfoAccessor.Abstraction;
using Adesso.Dapr.Core.Starter;
using Adesso.Dapr.Crypt.Service;
using Dapr.Client;

var builder = AdessoApplicationBuilder.CreateBuilder(new AdessoAppInfo
{
    Name = "Dapr.Crypt",
    Type = AppType.Api
}, args);


builder.Services.AddDaprClient();

builder.Services.AddSingleton<EncryptionService>(provider =>
{
    var daprClient = provider.GetRequiredService<DaprClient>();
    var encryptionKeySecret = daprClient.GetSecretAsync("my-secret-store", "encryptionKey").Result;
    return new EncryptionService(encryptionKeySecret["encryptionKey"]);
});

var app = builder.Build();
app.Run();