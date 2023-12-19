using Adesso.Dapr.Core.Domain.Abstraction;

namespace Adesso.Dapr.Core.Domain;

public abstract class AdessoDomainEventBase: IAdessoDomainEvent
{
    public DateTime OccurredOn { get; }
    
    public AdessoDomainEventBase()
    {
        this.OccurredOn = DateTime.Now;
    }
}