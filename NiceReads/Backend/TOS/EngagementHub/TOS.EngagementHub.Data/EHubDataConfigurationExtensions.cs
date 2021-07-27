using Microsoft.Extensions.DependencyInjection;
using TOS.EngagementHub.Data.Queries.Employees;
using TOS.EngagementHub.Data.Queries.SkillLevels;
using TOS.EngagementHub.Data.Queries.Skills;
using TOS.EngagementHub.Data.Repositories;
using TOS.EngagementHub.Data.Repositories.Implementations;

namespace TOS.EngagementHub.Data
{
    public static class EHubDataConfigurationExtensions
    {
        public static IServiceCollection AddEngagementHubData(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<ISkillRepository, SkillRepository>()
                .AddTransient<IEmployeesByFilterAsyncQuery, EmployeesByFilterAsyncQuery>()
                .AddTransient<IFindSkillsByNameAsyncQuery, FindSkillsByNameAsyncQuery>()
                .AddTransient<ISkillLevelRepository, SkillLevelRepository>()
                .AddTransient<IGetSkillLevelsAsyncQuery, GetSkillLevelsAsyncQuery>();
        }
    }
}
