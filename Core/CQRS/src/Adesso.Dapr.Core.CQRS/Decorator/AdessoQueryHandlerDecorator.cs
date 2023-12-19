using System.Diagnostics.CodeAnalysis;
using Adesso.Dapr.Core.CQRS.Abstraction.Handler;
using Adesso.Dapr.Core.CQRS.Abstraction.Message;
using Adesso.Dapr.Core.CQRS.Handler;

namespace Adesso.Dapr.Core.CQRS.Decorator;

[SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
internal sealed class AdessoQueryHandlerDecorator<TQuery, TResult> : AdessoQueryHandler<TQuery, TResult>
    where TQuery : IAdessoQuery<TResult>
    where TResult : class
{
    private readonly IAdessoQueryHandler<TQuery, TResult> _decorated;

    public AdessoQueryHandlerDecorator(
        IAdessoQueryHandler<TQuery, TResult> decorated,
        IServiceProvider serviceProvider)
    {
        _decorated = decorated;
       }

    public override async Task<TResult> Handle(TQuery request, CancellationToken cancellationToken)
    {
        TResult result;
            result = await this._decorated.Handle(request, cancellationToken);
            return result;
    }

}