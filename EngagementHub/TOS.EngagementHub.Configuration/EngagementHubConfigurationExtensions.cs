using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOS.Common;
using TOS.CQRS;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Application;
using TOS.EngagementHub.Data;

namespace TOS.EngagementHub.Configuration
{
    public static class EngagementHubConfigurationExtensions
    {
        public static IServiceCollection AddEngagementHub(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddCommon()
                .AddCQRS()
                .AddMongoDb(configuration)
                .AddEngagementHubData()
                .AddEngagementHubCQRS();
        }
    }
}
