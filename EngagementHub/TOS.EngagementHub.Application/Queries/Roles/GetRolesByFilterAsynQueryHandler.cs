using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.EngagementHub.Data.Queries.Roles;
using TOS.EngagementHub.Models;

namespace TOS.EngagementHub.Application.Queries.Roles
{
    public class GetRolesByFilterAsynQueryHandler : IAsyncQueryHandler<GetRolesByFilterAsynQuery, IReadOnlyCollection<Role>>
    {
        private readonly IRoleByFilterAsyncQuery _roleByFilterAsynQuery;

        public GetRolesByFilterAsynQueryHandler(IRoleByFilterAsyncQuery roleByFilterAsynQuery)
        {
            _roleByFilterAsynQuery = roleByFilterAsynQuery;
        }

        public async Task<IReadOnlyCollection<Role>> ExecuteAsync(GetRolesByFilterAsynQuery execution)
        {
            return await _roleByFilterAsynQuery.FindRolesAsync(execution.Filter);
        }
    }
}
