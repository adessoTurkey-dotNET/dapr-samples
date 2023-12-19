namespace Adesso.Dapr.Core.InfoAccessor.Abstraction.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class InfoFromConfigurationAttribute : InfoBaseAttribute
{
    public string Key { get; set; }

    public InfoFromConfigurationAttribute(string key)
    {
        Key = key;
    }
}