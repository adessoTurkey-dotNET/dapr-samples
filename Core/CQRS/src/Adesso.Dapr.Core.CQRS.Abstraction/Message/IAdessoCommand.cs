namespace Adesso.Dapr.Core.CQRS.Abstraction.Message;

public interface IAdessoCommand : IAdessoRequest<bool>
{
    string CommandId { get; set; }
}

public interface IAdessoCommand<out TResult> : IAdessoRequest<TResult>
{
    string CommandId { get; }
}