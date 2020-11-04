using Microsoft.Extensions.DependencyInjection;
using TOS.Data.Security.Repositories;
using TOS.Data.Security.Repositories.Implementations;

namespace TOS.Configuration.Security
{
    internal static class RepositoriesConfiguration
    {
        public static void AddResporitories(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IRoleRepository, RoleRepository>();
        }
    }
}
