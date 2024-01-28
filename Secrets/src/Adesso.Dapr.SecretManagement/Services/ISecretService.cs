using Adesso.Dapr.SecretManagement.Models;

namespace Adesso.Dapr.SecretManagement.Services;

public interface ISecretService
{
    Task<SecretModel> GetSecretAsync(string key);
}