using Adesso.Dapr.Core.Domain.Abstraction;
using Adesso.Dapr.Core.Domain.Abstraction.Excepotion;

namespace Adesso.Dapr.Core.Domain;

public interface IAdessoEntity
{
}

public abstract class AdessoEntityWithApproval : AdessoEntityWithAudit
{
    protected AdessoEntityWithApproval()
    {
        ApprovalStatus = ApprovalStatus.Pending;
        StartDate = DateTime.Now;
    }

    public bool IsActive
    {
        get
        {
            if (ApprovalStatus == ApprovalStatus.Approved)
            {
                if (EndDate.HasValue)
                {
                    return StartDate <= DateTime.Now && EndDate.Value > DateTime.Now;
                }

                return StartDate <= DateTime.Now;
            }

            return false;
        }
    }

    public ApprovalStatus ApprovalStatus { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}

public enum ApprovalStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = 2
}

public abstract class AdessoEntityWithAudit : AdessoEntity
{
    public string? ModifyHost { get; set; }

    public long? ModifyUserId { get; set; }

    public DateTime? ModifyDate { get; set; }

    public long? CreateUserId { get; set; }

    public string? CreateHost { get; set; }

    public DateTime? CreateDate { get; set; }
}

public abstract class AdessoEntity : IAdessoEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }

    private List<IAdessoDomainEvent> _domainEvents;

    /// <summary>
    /// Add domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void AddDomainEvent(IAdessoDomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<IAdessoDomainEvent>();
        this._domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clear domain events.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    protected static void CheckRule(IAdessoBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new AdessoBusinessRuleValidationException(rule);
        }
    }
}