using Adesso.Dapr.Core.CQRS.Abstraction.Message;
using MiniUow.Paging;

namespace Adesso.Dapr.Core.CQRS.Message;

public abstract class AdessoQuery<TResult> : IAdessoQuery<TResult>
{
    public string QueryId { get; }

    protected AdessoQuery()
    {
        this.QueryId = Guid.NewGuid().ToString();
    }
}

public abstract class AdessoListedQuery<TItem> : AdessoQuery<IList<TItem>>
{
}

public abstract class AdessoPagedQuery<TItem> : AdessoQuery<IPaginate<TItem>>
{
}

