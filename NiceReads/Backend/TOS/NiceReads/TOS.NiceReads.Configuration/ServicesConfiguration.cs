using Microsoft.Extensions.DependencyInjection;
using TOS.NiceReads.Application.Services.Authentication;
using TOS.NiceReads.Application.Services.Logins;
using TOS.NiceReads.Application.Utils;

namespace TOS.NiceReads.Configuration
{
    internal static class ServicesConfiguration
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IAuthenticator, Authenticator>()
                .AddTransient<ILoginHistoryManager, LoginHistoryManager>()
                .AddTransient<IPasswordUtils, PasswordUtils>();
        }
    }
}
