namespace Adesso.Dapr.Core.Domain;

public class AdessoTypedIdValueBase : IEquatable<AdessoTypedIdValueBase>
{
    public Guid Value { get; }

    protected AdessoTypedIdValueBase(Guid value)
    {
        Value = value;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj is AdessoTypedIdValueBase other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public bool Equals(AdessoTypedIdValueBase other)
    {
        return this.Value == other.Value;
    }

    public static bool operator ==(AdessoTypedIdValueBase obj1, AdessoTypedIdValueBase obj2)
    {
        if (object.Equals(obj1, null))
        {
            if (object.Equals(obj2, null))
            {
                return true;
            }
            return false;
        }
        return obj1.Equals(obj2);
    }
    
    public static bool operator !=(AdessoTypedIdValueBase x, AdessoTypedIdValueBase y)
    {
        return !(x == y);
    }
}