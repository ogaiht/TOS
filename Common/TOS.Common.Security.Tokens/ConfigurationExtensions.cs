using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOS.Common.Configuration;
using TOS.Common.Security.Tokens.Factories;
using TOS.Common.Security.Tokens.Utils;

namespace TOS.Common.Security.Tokens
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            ISecurityConfig securityConfig = configuration.GetConfig<TokenSecurityConfig>();
            return services
                .AddSingleton(securityConfig)
                .AddTransient<ISecurityTokenCreator, JwtSecurityTokenCreator>()
                .AddTransient<IEncryptingCredentialsFactory, EncryptingCredentialsFactory>()
                .AddTransient<ISigningCredentialsFactory, SigningCredentialsFactory>()
                .AddTransient<ISymmetricSecurityKeyFactory, SymmetricSecurityKeyFactory>()
                .AddTransient<ITokenTimerProvider, TokeTimerProvider>();
        }
    }
}
