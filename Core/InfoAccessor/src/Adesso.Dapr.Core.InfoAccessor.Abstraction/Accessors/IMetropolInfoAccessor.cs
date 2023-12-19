namespace Adesso.Dapr.Core.InfoAccessor.Abstraction;

public interface IAdessoInfoAccessor
{
    public IAdessoAppInfoAccessor AppInfoAccessor { get; }
    public TInfo GetInfo<TInfo>() where TInfo : IAdessoInfo;
}