namespace Adesso.Dapr.Core.InfoAccessor.Abstraction;

public interface IAdessoAppInfoAccessor
{
    public AdessoAppInfo AppInfo { get; }
}

public enum AppType
{
    Api,
    Gateway,
    Bff,
    Worker,
    Scheduler
}

public class AdessoAppInfo : IAdessoInfo
{
    public InfoLifeCycle LifeCycle => InfoLifeCycle.Singleton;

    public AppType Type { get; set; }
    
    public string Name { get; set; }
}