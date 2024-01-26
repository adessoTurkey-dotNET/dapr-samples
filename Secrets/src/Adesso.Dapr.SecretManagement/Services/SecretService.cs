using Dapr.Client;
using DaprSecretManagement.Models;

namespace DaprSecretManagement.Services;

public class SecretService : ISecretService
{
    private readonly DaprClient _daprClient;

    public SecretService(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task<SecretModel> GetSecretAsync(string key)
    {
        var secret = await _daprClient.GetSecretAsync("local-secret-store", key);
        return new SecretModel()
        {
            Key = key,
            Value = secret[key]
        };
    }
}