using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOS.Common;
using TOS.Data.MongoDB;

namespace TOS.EngagementHub.DataBase.Config
{
    public static class UpdaterBuilder
    {
        public static IDatabaseUpdater CreateUpdater()
        {
            IServiceCollection serviceCollecion = new ServiceCollection();
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            return serviceCollecion
                .AddCommon()
                .AddMongoDb(configuration)
                .AddSingleton<IDatabaseUpdater, DatabaseUpdater>()
                .BuildServiceProvider()
                .GetService<IDatabaseUpdater>();
        }
    }
}
