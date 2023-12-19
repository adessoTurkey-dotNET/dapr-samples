namespace Adesso.Dapr.Core.InfoAccessor.Abstraction;

public interface IAdessoInfo
{
    public InfoLifeCycle LifeCycle { get; }
}

public enum InfoLifeCycle
{
    Singleton,
    Scoped
}