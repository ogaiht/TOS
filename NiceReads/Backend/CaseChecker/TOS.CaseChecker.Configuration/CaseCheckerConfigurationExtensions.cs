using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TOS.CaseChecker.Application;
using TOS.Common;
using TOS.CQRS;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Data;

namespace TOS.CaseChecker.Configuration
{
    public static class CaseCheckerConfigurationExtensions
    {
        public static IServiceCollection AddCaseChecker(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddCommon()
                .AddCQRS()
                .AddMongoDb(configuration)
                .AddCaseCheckerApp()
                .AddCaseCheckData();
        }
    }
}
