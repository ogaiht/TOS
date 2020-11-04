using Microsoft.Extensions.DependencyInjection;
using TOS.Common.Security.Cryptography;
using TOS.Common.Security.Cryptography.HMACSHA_512;

namespace TOS.Common.Security
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddCommonSecurity(this IServiceCollection services)
        {
            return services
                .AddTransient<ITextHashHelper, TextHashHelper>()
                .AddTransient<IHashGenerator, HMACSHA512HashGenerator>();
        }
    }
}
