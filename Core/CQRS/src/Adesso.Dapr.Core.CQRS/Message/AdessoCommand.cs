using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Message;

public abstract class AdessoCommand : IAdessoCommand
{
    public string CommandId { get; set; }

    protected AdessoCommand()
    {
        this.CommandId = Guid.NewGuid().ToString();
    }
}

public abstract class AdessoCommand<TResult> : IAdessoCommand<TResult>
{
    public string CommandId { get; }

    protected AdessoCommand()
    {
        this.CommandId = Guid.NewGuid().ToString();
    }
}