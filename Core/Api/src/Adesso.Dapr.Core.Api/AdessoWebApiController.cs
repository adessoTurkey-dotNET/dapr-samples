using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Dapr.Core.Infrastructure.Api;

[ApiController]
[Route("api/[controller]")]
public class AdessoWebApiController : ControllerBase
{
    protected IHttpContextAccessor ContextAccessor { get; }

    public AdessoWebApiController(IHttpContextAccessor httpContextAccessor)
    {
        ContextAccessor = httpContextAccessor;
    }

    protected AdessoApiResponse<T> SetResponse<T>(T data) where T : class
    {
        var response = new AdessoApiResponse<T>(AdessoResponseHeader.Success(), data);
        return response;
    }
}