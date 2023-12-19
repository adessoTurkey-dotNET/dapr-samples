namespace Adesso.Dapr.Core.CQRS.Abstraction.Message;

public interface IAdessoQuery<TResult> : IAdessoRequest<TResult>
{
    string QueryId { get; }
}