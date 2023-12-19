using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Adesso.Dapr.Core.IOC.Abstraction.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ToScan(this IServiceCollection services,
            Action<ITypeSourceSelector> action)
        {
            return services.Scan(action);
        }

        public static IServiceCollection ToDecorate<TService, TDecorator>(this IServiceCollection services)
            where TDecorator : TService
        {
            return services.Decorate<TService, TDecorator>();
        }

        public static IServiceCollection ToDecorate(this IServiceCollection services,
            Type serviceType,
            Type decoratorType)
        {
            return services.Decorate(serviceType, decoratorType);
        }

        public static IServiceCollection ToDecorate<TService>(this IServiceCollection services,
            Func<TService, IServiceProvider, TService> decorator)
        {
            return services.Decorate(decorator);
        }

        public static IServiceCollection ToDecorate<TService>(this IServiceCollection services,
            Func<TService, TService> decorator)
        {
            return services.Decorate(decorator);
        }

        public static IServiceCollection ToDecorate(this IServiceCollection services,
            Type serviceType,
            Func<object, IServiceProvider, object> decorator)
        {
            return services.Decorate(serviceType, decorator);
        }

        public static IServiceCollection ToDecorate(this IServiceCollection services,
            Type serviceType,
            Func<object, object> decorator)
        {
            return services.Decorate(serviceType, decorator);
        }

        public static bool ToTryDecorate<TService, TDecorator>(this IServiceCollection services)
            where TDecorator : TService
        {
            return services.TryDecorate<TService, TDecorator>();
        }

        public static bool ToTryDecorate(this IServiceCollection services,
            Type serviceType,
            Type decoratorType)
        {
            return services.TryDecorate(serviceType, decoratorType);
        }

        public static bool ToTryDecorate<TService>(this IServiceCollection services,
            Func<TService, IServiceProvider, TService> decorator)
        {
            return services.TryDecorate(decorator);
        }

        public static bool ToTryDecorate<TService>(this IServiceCollection services,
            Func<TService, TService> decorator)
        {
            return services.TryDecorate(decorator);
        }

        public static bool ToTryDecorate(this IServiceCollection services,
            Type serviceType,
            Func<object, IServiceProvider, object> decorator)
        {
            return services.TryDecorate(serviceType, decorator);
        }

        public static bool ToTryDecorate(this IServiceCollection services,
            Type serviceType,
            Func<object, object> decorator)
        {
            return services.TryDecorate(serviceType, decorator);
        }
    }
}
