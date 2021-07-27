using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TOS.CQRS;
using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Application.Commands.SkillLevels;
using TOS.EngagementHub.Application.Commands.Skills;
using TOS.EngagementHub.Application.Mappings.Commands.Employees;
using TOS.EngagementHub.Application.Mappings.Skills;
using TOS.EngagementHub.Application.Queries.Employees;
using TOS.EngagementHub.Application.Queries.SkillLevels;
using TOS.EngagementHub.Application.Queries.Skills;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Application
{
    public static class EHubApplicationConfigurationExtensions
    {
        public static IServiceCollection AddEngagementHubCQRS(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddCommands()
                .AddQueries()
                .AddMappings();
        }

        private static IServiceCollection AddCommands(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncCommand<CreateEmployeeAsyncCommand, Guid, CreateEmployeeAsyncCommandHandler>()
                .AddAsyncCommand<CreateSkillAsyncCommand, Guid, CreateSkillAsyncCommandHandler>()
                .AddAsyncCommand<AddSkillsToEmployeeAsyncCommand, AddSkillsToEmployeeAsyncCommandHandle>()
                .AddAsyncCommand<CreateSkillLevelAsyncCommand, Guid, CreateSkillLevelAsyncCommandHandler>();
        }

        private static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncQuery<GetSkillByIdAsyncQuery, Skill, GetSkillByIdAsyncQueryHandle>()
                .AddAsyncQuery<GetSkillsByNameAsyncQuery, IReadOnlyCollection<Skill>, GetSkillsByNameAsyncQueryHandler>()
                .AddAsyncQuery<GetEmployeesByFilterAsyncQuery, IReadOnlyCollection<EmployeeDetail>, GetEmployeesByFilterAsyncQueryHandler>()
                .AddAsyncQuery<GetSkillLevelsAsyncQuery, IReadOnlyCollection<SkillLevel>, GetSkillLevelsAsyncQueryHandler>();
        }

        private static IServiceCollection AddMappings(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ICreateEmployeeAsyncCommandToEmployeeParser, CreateEmployeeAsyncCommandToEmployeeParser>()
                .AddSingleton<ICreateSkillAsyncCommandToSkillParser, CreateSkillAsyncCommandToSkillParser>();
        }
    }
}
