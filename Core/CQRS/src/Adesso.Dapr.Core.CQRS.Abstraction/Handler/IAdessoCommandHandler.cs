using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Abstraction.Handler;


public interface IAdessoCommandHandler<in TCommand, TResult> : IAdessoRequestHandler<TCommand, TResult>
    where TCommand : IAdessoCommand<TResult>
{
}