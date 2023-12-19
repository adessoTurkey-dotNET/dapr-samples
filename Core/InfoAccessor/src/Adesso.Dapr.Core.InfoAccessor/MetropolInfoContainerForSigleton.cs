using System.Collections.Concurrent;
using Adesso.Dapr.Core.InfoAccessor.Abstraction;

namespace Adesso.Dapr.Core.InfoAccessor;

public class AdessoInfoContainerForSigleton
{
    private ConcurrentDictionary<Type, object> _infoDictionary;

    public AdessoInfoContainerForSigleton()
    {
        _infoDictionary = new ConcurrentDictionary<Type, object>();
    }

    public bool TryGetValue<TAdessoInfo>(out TAdessoInfo result) where TAdessoInfo : IAdessoInfo
    {
        if (_infoDictionary.TryGetValue(typeof(TAdessoInfo), out var r))
        {
            result = (TAdessoInfo) r;
            return true;
        }

        result = default;
        return false;
    }

    public void Set<TAdessoInfo>(TAdessoInfo info) where TAdessoInfo : IAdessoInfo
    {
        _infoDictionary.AddOrUpdate(
            typeof(TAdessoInfo),
            t => info,
            (t, o) => o
        );
    }
}