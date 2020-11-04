using Microsoft.Extensions.DependencyInjection;
using TOS.Application.Security.Queries.Roles;
using TOS.Application.Security.QueryHandlers.Roles;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.Security.Models;

namespace TOS.Configuration.Security
{
    public static class QueryConfiguration
    {
        public static void AddQueries(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IAsyncQueryHandler<GetRolesByNameAsyncQuery, IPagedResult<Role>>, GetRolesByNameAsynQueryHandler>()
                .AddTransient<IAsyncQueryHandler<GetAllRolesAsyncQuery, IPagedResult<Role>>, GetAllRolesAsyncQueryHandler>();
        }
    }
}
