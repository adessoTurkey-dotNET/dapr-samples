using MediatR;
using Adesso.Dapr.Core.CQRS.Abstraction.Message;

namespace Adesso.Dapr.Core.CQRS.Abstraction.Handler;

public interface IAdessoRequestHandler<in TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IAdessoRequest<TResult>
{
    
}