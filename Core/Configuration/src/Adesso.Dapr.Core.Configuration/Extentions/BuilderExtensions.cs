using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adesso.Dapr.Core.Configuration.Extentions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection ConfigureDictionary<TOptions, TValue>(this IServiceCollection services,
            IConfigurationSection section
        ) where TOptions : class, IDictionary<string, TValue>
        {
            var values = section
                .GetChildren()
                .ToList();
            services.Configure<TOptions>(x =>
                values.ForEach(v => x.Add(v.Key, v.Get<TValue>()))
            );

            return services;
        }

        public static IServiceCollection ConfigureList<TOptions>(this IServiceCollection services,
            IConfigurationSection section
        ) where TOptions : class, IList<string>
        {
            var values = section
                .GetChildren()
                .ToList();

            services.Configure<TOptions>(x =>
                values.ForEach(v => x.Add(v.Value))
            );

            return services;
        }
    }
}