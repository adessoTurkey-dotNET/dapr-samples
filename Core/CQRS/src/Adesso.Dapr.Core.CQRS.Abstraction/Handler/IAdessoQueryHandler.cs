using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Abstraction.Handler;

public interface IAdessoQueryHandler<in TQuery, TResult> : IAdessoRequestHandler<TQuery, TResult>
    where TQuery : IAdessoQuery<TResult>
{
    
}

public interface IAdessoGenericHandler
{
    
}