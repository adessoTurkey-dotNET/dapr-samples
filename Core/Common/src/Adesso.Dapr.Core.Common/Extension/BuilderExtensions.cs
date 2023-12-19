using Adesso.Dapr.Core.Common.Abstraction.Exception;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLocalizator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Adesso.Dapr.Core.Common.Extension
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddAdessoException<TException>(this IServiceCollection services, IConfiguration configuration) where TException : AdessoException
        {
            var EntryAssembly = Assembly.GetEntryAssembly();

            var path = Path.GetDirectoryName(EntryAssembly.Location);
            var moduleAssemblies = Directory
                .GetFiles(path, "Adesso.*.dll", SearchOption.TopDirectoryOnly)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .ToList();

            services.AddLocalizator<TException>(options =>
                options.AddFolderPath(@"C:\Users\tcakir\Desktop\OKR\Localizator\samples\NLocalizator.Sample\Lang\Weather")
                 .AddLanguage("tr"));

            return services;
        }
    }
}
