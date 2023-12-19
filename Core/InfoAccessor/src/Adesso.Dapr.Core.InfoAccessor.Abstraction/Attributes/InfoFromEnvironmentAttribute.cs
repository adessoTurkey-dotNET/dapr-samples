namespace Adesso.Dapr.Core.InfoAccessor.Abstraction.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class InfoFromEnvironmentAttribute : InfoBaseAttribute
{
    public string Key { get; set; }

    public InfoFromEnvironmentAttribute(string key)
    {
        Key = key;
    }
}