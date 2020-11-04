using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOS.Common;
using TOS.Common.Config;
using TOS.Common.Security;
using TOS.Common.Text.Semantics;
using TOS.Common.Text.Semantics.English;
using TOS.CQRS;

namespace TOS.NiceReads.Configuration
{
    public class NiceReadsConfigurator : IAppConfigurator
    {
        public void AddConfiguration(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .AddCommon()
                .AddCommonSecurity()
                .AddCQRS()
                .AddCommands()
                .AddResporitories()
                .AddQueries()
                .AddServices()
                .AddMongoDb(configuration)            
                .AddTransient<IPlurilizer, Plurilizer>();
        }
    }
}
