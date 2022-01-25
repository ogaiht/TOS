using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace TOS.Common.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static bool Contains<TService>(this IServiceCollection serviceCollection)
        {
            return serviceCollection.Any(s => s.ServiceType == typeof(TService));
        }

        public static IServiceCollection AddSingletonIfNotFound<TService, TImplementation>(this IServiceCollection serviceCollection)
            where TService : class
            where TImplementation : class, TService
        {
            if (!serviceCollection.Contains<TService>())
            {
                serviceCollection.AddSingleton<TService, TImplementation>();
            }
            return serviceCollection;
        }
    }
}
