using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TOS.CaseChecker.Application.Commands.CasesInfo;
using TOS.CaseChecker.Application.Queries.CaseInfos;
using TOS.CaseChecker.Application.Utils;
using TOS.CQRS;

namespace TOS.CaseChecker.Application
{
    public static class CaseCheckerApplicationConfigurationExtensions
    {
        public static IServiceCollection AddCaseCheckerApp(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddCommands()
                .AddQueries()
                .AddUtils();
        }
        private static IServiceCollection AddCommands(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncCommand<LoadAllCasesForDateAsyncCommand, CasesReport, LoadAllCasesForDateAsyncCommandHandler>()
                .AddAsyncCommand<UpdateCaseInfosAsyncCommand, CasesUpdatedReport, UpdateCaseInfosAsyncCommandHandler>()
                .AddAsyncCommand<LoadAllCasesBetweenDatesAsyncCommand, IReadOnlyCollection<CasesReport>, LoadAllCasesBetweenDatesAsyncCommandHandler>()
                .AddAsyncCommand<CheckForUpdatesAsyncCommand, IReadOnlyCollection<CasesUpdatedReport>, CheckForUpdatesAsyncCommandHandler>();
        }

        private static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddAsyncQuery<GetEmploeeysByDateAsyncQuery, IEnumerable<string>, GetEmploeeysByDateAsyncQueryHandler>()
                .AddAsyncQuery<GetCasesByEmployeeAsyncQuery, IReadOnlyCollection<CaseReportByEmployer>, GetCasesByEmployeeAsyncQueryHandler>()
                .AddAsyncQuery<GetCasesDatesAsyncQuery, IReadOnlyCollection<DateTime>, GetCasesDatesAsyncQueryHandler>();
        }

        private static IServiceCollection AddUtils(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<ICaseInfoDiscoverer, CaseInfoDiscoverer>()
                .AddTransient<ICaseInfoLoader, CaseInfoLoader>()
                .AddTransient<ICaseInfoParser, CaseInfoParser>()
                .AddTransient<ICaseNumberGenerator, CaseNumberGenerator>()
                .AddTransient<ICaseQueryBuilderConfig, CaseQueryBuilderConfig>()
                .AddTransient<ICaseUrlQueryBuilder, CaseUrlQueryBuilder>()
                .AddTransient<IHttpDataLoader, HttpDataLoader>()
                .AddTransient<IJulianDateConverter, JulianDateConverter>()
                .AddTransient<ICaseInfoReportBuilder, CaseInfoReportBuilder>()
                .AddTransient<IStartingPointProvider, StartingPointProvider>()
                .AddTransient<ICasesLoader, CasesLoader>()
                .AddTransient<IDailyCasesLoader, DailyCasesLoader>()
                .AddTransient<ICaseUpdater, CaseUpdater>();
        }
    }
}
