using Adesso.Dapr.Core.CQRS.Abstraction.Handler;
using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Handler;

public abstract class AdessoQueryHandler<TQuery, TResult> : IAdessoQueryHandler<TQuery, TResult>
    where TQuery : IAdessoQuery<TResult>
{
    public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
}