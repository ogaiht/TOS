using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TOS.Common.Config
{
    public interface IAppConfigurator
    {
        void AddConfiguration(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
