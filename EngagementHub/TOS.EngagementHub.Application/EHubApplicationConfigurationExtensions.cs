using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TOS.Common.DataModel;
using TOS.CQRS;
using TOS.EngagementHub.Application.Commands.Cities;
using TOS.EngagementHub.Application.Commands.Countries;
using TOS.EngagementHub.Application.Commands.Employees;
using TOS.EngagementHub.Application.Commands.SkillLevels;
using TOS.EngagementHub.Application.Commands.Skills;
using TOS.EngagementHub.Application.Commands.States;
using TOS.EngagementHub.Application.Mappings.Commands.Employees;
using TOS.EngagementHub.Application.Mappings.Skills;
using TOS.EngagementHub.Application.Queries.Cities;
using TOS.EngagementHub.Application.Queries.Countries;
using TOS.EngagementHub.Application.Queries.Employees;
using TOS.EngagementHub.Application.Queries.SkillLevels;
using TOS.EngagementHub.Application.Queries.Skills;
using TOS.EngagementHub.Application.Queries.States;
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
                .AddAsyncCommand<CreateSkillLevelAsyncCommand, Guid, CreateSkillLevelAsyncCommandHandler>()
                .AddAsyncCommand<RemoveSkillsFromEmployeeAsyncCommand, RemoveSkillsFromEmployeeAsyncCommandHandler>()
                .AddAsyncCommand<DeleteEmployeeAsyncCommand, DeleteEmployeeAsyncCommandHandler>()
                .AddAsyncCommand<CreateCityAsyncCommand, Guid, CreateCityAsyncCommandHandler>()
                .AddAsyncCommand<CreateCountryAsyncCommand, Guid, CreateCountryAsyncCommandHandler>()
                .AddAsyncCommand<CreateStateAsyncCommand, Guid, CreateStateAsyncCommandHandler>();
        }

        private static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncQuery<GetSkillByIdAsyncQuery, Skill, GetSkillByIdAsyncQueryHandle>()
                .AddAsyncQuery<GetSkillsByNameAsyncQuery, IPagedResult<Skill>, GetSkillsByNameAsyncQueryHandler>()
                .AddAsyncQuery<GetEmployeesByFilterAsyncQuery, IPagedResult<EmployeeDetail>, GetEmployeesByFilterAsyncQueryHandler>()
                .AddAsyncQuery<GetSkillLevelsAsyncQuery, IReadOnlyCollection<SkillLevel>, GetSkillLevelsAsyncQueryHandler>()
                .AddAsyncQuery<GetEmployeeByIdAsyncQuery, EmployeeDetail, GetEmployeeByIdAsyncQueryHandler>()
                .AddAsyncQuery<GetCountriesAsyncQuery, IPagedResult<Country>, GetCountriesAsyncQueryHandler>()
                .AddAsyncQuery<GetStatesAsyncQuery, IPagedResult<State>, GetStatesAsyncQueryHandler>()
                .AddAsyncQuery<GetCitiesAsyncQuery, IPagedResult<City>, GetCitiesAsyncQueryHandler>();
        }

        private static IServiceCollection AddMappings(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ICreateEmployeeAsyncCommandToEmployeeParser, CreateEmployeeAsyncCommandToEmployeeParser>()
                .AddSingleton<ICreateSkillAsyncCommandToSkillParser, CreateSkillAsyncCommandToSkillParser>();
        }
    }
}
