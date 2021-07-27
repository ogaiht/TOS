using Microsoft.Extensions.DependencyInjection;
using TOS.Common.Text.Semantics.English;

namespace TOS.Common.Text.Semantics
{
    public static class SemanticsConfigurationExtensions
    {
        public static IServiceCollection AddSemantics(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IPlurilizer, Plurilizer>();
        }
    }
}
