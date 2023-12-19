namespace Adesso.Dapr.Core.Common.Abstraction.Patterns;

public class SingletonBase<T>
    where T : class
{
    private static readonly Lazy<T> _instance = new(CreateInstanceOfT);

    protected SingletonBase()
    {
    }

    public static T GetInstance()
    {
        return _instance.Value;
    }

    private static T CreateInstanceOfT()
    {
        return Activator.CreateInstance(typeof(T), true) as T;
    }
}