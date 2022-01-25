using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;

namespace TOS.EngagementHub.Application.Queries.Roles
{
    public class GetRolesByFilterAsynQuery : AsyncQuery<IReadOnlyCollection<Role>>
    {
        public GetRolesByFilterAsynQuery(RoleFilter filter)
        {
            Filter = filter;
        }

        public RoleFilter Filter { get; }
    }
}
