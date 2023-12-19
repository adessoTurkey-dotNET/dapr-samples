using System.Reflection;
using Adesso.Dapr.Core.InfoAccessor.Abstraction;
using Adesso.Dapr.Core.InfoAccessor.Abstraction.Attributes;
using Adesso.Dapr.Core.InfoAccessor.Extensions;
using Microsoft.Extensions.Configuration;

namespace Adesso.Dapr.Core.InfoAccessor;

internal class AdessoInfoAccessor : IAdessoInfoAccessor,  IAdessoAppInfoAccessor
{
    private readonly IAdessoInfoContainer _infoContainer;

    private readonly IConfiguration _configuration;

    public IAdessoAppInfoAccessor AppInfoAccessor => this;

    public AdessoAppInfo AppInfo => _infoContainer.Get<AdessoAppInfo>();

    public AdessoInfoAccessor(IAdessoInfoContainer infoContainer, IConfiguration configuration)
    {
        _infoContainer = infoContainer;
        _configuration = configuration;
    }

    public TInfo GetInfo<TInfo>() where TInfo : IAdessoInfo
    {
        var infoType = typeof(TInfo);
        var info = Activator.CreateInstance(infoType);
        foreach (var property in info.GetType().GetProperties()
                     .Where(x => x.CustomAttributes.Any(a => a.AttributeType.IsSubclassOf(typeof(InfoBaseAttribute)))))
        {
            object value;
            var baseAttribute = property.GetCustomAttribute<InfoBaseAttribute>();
            switch (baseAttribute)
            {
                case InfoFromConfigurationAttribute infoBaseAttribute:
                    {
                        value = _configuration[infoBaseAttribute.Key];
                        break;
                    }
                case InfoFromEnvironmentAttribute infoBaseAttribute:
                    {
                        value = Environment.GetEnvironmentVariable(infoBaseAttribute.Key);
                        break;
                    }
                default:
                    throw new NotSupportedException($"{baseAttribute.GetType().FullName} not supported");
            }

            property.SetValue(info, property.ConvertToPropertyType(value));
        }

        return (TInfo)info;
    }
}