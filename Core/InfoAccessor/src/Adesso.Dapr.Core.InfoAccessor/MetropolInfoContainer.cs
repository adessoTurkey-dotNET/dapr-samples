using Adesso.Dapr.Core.InfoAccessor.Abstraction;

namespace Adesso.Dapr.Core.InfoAccessor;

internal class AdessoInfoContainer : IAdessoInfoContainer
{
    private readonly AdessoInfoContainerForSigleton _containerForSigleton;

    private readonly AdessoInfoContainerForScoped _containerForScoped;

    public AdessoInfoContainer(AdessoInfoContainerForSigleton containerForSigleton,
        AdessoInfoContainerForScoped containerForScoped
    )
    {
        _containerForSigleton = containerForSigleton;
        _containerForScoped = containerForScoped;
    }

    public TAdessoInfo Get<TAdessoInfo>() where TAdessoInfo : IAdessoInfo
    {
        if (_containerForScoped.TryGetValue<TAdessoInfo>(out var result))
        {
            return result;
        }

        if (_containerForSigleton.TryGetValue<TAdessoInfo>(out result))
        {
            return result;
        }

        return default;
    }

    public void Set<TAdessoInfo>(TAdessoInfo info) where TAdessoInfo : IAdessoInfo
    {
        switch (info.LifeCycle)
        {
            case InfoLifeCycle.Singleton:
                _containerForSigleton.Set(info);
                break;
            case InfoLifeCycle.Scoped:
                _containerForScoped.Set(info);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

  
}