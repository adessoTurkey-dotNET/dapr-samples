using Adesso.Dapr.Core.CQRS.Abstraction.Handler;
using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Handler;

public abstract class AdessoCommandHandler<TCommand, TResult> : IAdessoCommandHandler<TCommand, TResult>
    where TCommand : IAdessoCommand<TResult>
{
    public abstract Task<TResult?> Handle(TCommand request, CancellationToken cancellationToken);
}