using Microsoft.Extensions.DependencyInjection;
using TOS.EngagementHub.Data.Queries.Cities;
using TOS.EngagementHub.Data.Queries.Countries;
using TOS.EngagementHub.Data.Queries.Employees;
using TOS.EngagementHub.Data.Queries.SkillLevels;
using TOS.EngagementHub.Data.Queries.Skills;
using TOS.EngagementHub.Data.Queries.States;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Data.Repositories.Implementations;

namespace TOS.EngagementHub.Data
{
    public static class EHubDataConfigurationExtensions
    {
        public static IServiceCollection AddEngagementHubData(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddRepositories()
                .AddQueries();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<ICityRepository, CityRepository>()
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<ISkillRepository, SkillRepository>()
                .AddTransient<ISkillLevelRepository, SkillLevelRepository>()
                .AddTransient<IStateRepository, StateRepository>();
        }

        private static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IEmployeesByFilterAsyncQuery, EmployeesByFilterAsyncQuery>()
                .AddTransient<IFindSkillsByNameAsyncQuery, FindSkillsByNameAsyncQuery>()
                .AddTransient<IGetSkillLevelsAsyncQuery, GetSkillLevelsAsyncQuery>()
                .AddTransient<IEmployeeDetailComposer, EmployeeDetailComposer>()
                .AddTransient<IGetCountrisAsyncQuery, GetCountrisAsyncQuery>()
                .AddTransient<IGetStatesAsyncQuery, GetStatesAsyncQuery>()
                .AddTransient<IGetCitiesAsyncQuery, GetCitiesAsyncQuery>();
        }
    }
}
