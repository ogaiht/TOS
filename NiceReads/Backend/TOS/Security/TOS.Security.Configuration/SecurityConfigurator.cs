using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOS.Common.Config;

namespace TOS.Configuration.Security
{
    public class SecurityConfigurator : IAppConfigurator
    {
        public void AddConfiguration(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            CommandsConfiguration.AddCommands(serviceCollection);
            RepositoriesConfiguration.AddResporitories(serviceCollection);
            QueryConfiguration.AddQueries(serviceCollection);
        }
    }
}
