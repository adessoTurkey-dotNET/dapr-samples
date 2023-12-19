using Adesso.Dapr.Core.Starter.Abstraction;
using Microsoft.AspNetCore.Builder;

namespace Adesso.Dapr.Core.Starter.Api;

public sealed class AdessoApiApplication : AdessoApplication
{
    public AdessoApiApplication(WebApplication application) : base(application)
    {
    }
}