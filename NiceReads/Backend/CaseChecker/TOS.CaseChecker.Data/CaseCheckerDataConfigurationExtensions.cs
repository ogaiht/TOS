using Microsoft.Extensions.DependencyInjection;
using TOS.CaseChecker.Data.Queries.Cases;
using TOS.CaseChecker.Data.Repositories;
using TOS.CaseChecker.Data.Repositories.Implementations;

namespace TOS.EngagementHub.Data
{
    public static class CaseCheckerDataConfigurationExtensions
    {
        public static IServiceCollection AddCaseCheckData(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddRepositories()
                .AddQueries();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<ICaseInfoRepository, CaseInfoRepository>()
                .AddTransient<IUpdateCheckRepository, UpdateCheckRepository>();
        }

        private static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IGetCaseDatesAsyncQuery, GetCaseDatesAsyncQuery>()
                .AddTransient<IGetCaseDatesToCheckForUpdateAsyncQuery, GetCaseDatesToCheckForUpdateAsyncQuery>();
        }
    }
}
