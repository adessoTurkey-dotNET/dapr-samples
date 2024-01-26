using Adesso.Dapr.SecretManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Dapr.SecretManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{
    private readonly ISecretService _secretService;

    public SecretController(ISecretService secretService)
    {
        _secretService = secretService;
    }

    [HttpGet("{key}")]
    public async Task<IActionResult> GetSecret(string key)
    {
        var secret = await _secretService.GetSecretAsync(key);
        return Ok(secret);
    }
}