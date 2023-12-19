namespace Adesso.Dapr.Core.InfoAccessor.Abstraction;

public interface IAdessoInfoContainer
{
    public TAdessoInfo Get<TAdessoInfo>() where TAdessoInfo : IAdessoInfo;
    
    public void Set<TAdessoInfo>(TAdessoInfo info) where TAdessoInfo : IAdessoInfo;
}