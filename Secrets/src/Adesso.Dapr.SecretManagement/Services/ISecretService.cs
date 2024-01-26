using DaprSecretManagement.Models;

namespace DaprSecretManagement.Services;

public interface ISecretService
{
    Task<SecretModel> GetSecretAsync(string key);
}