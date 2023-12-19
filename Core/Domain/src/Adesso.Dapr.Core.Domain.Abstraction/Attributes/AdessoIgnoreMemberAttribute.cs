namespace Adesso.Dapr.Core.Domain.Abstraction.Attributes;

public class AdessoIgnoreMemberAttribute
{
    
}

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class AdessoSearchableAttribute : Attribute
{
    public AdessoSearchableAttribute() { }
}