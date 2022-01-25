using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;

namespace TOS.EngagementHub.Data.Queries.Roles
{
    public interface IRoleByFilterAsyncQuery
    {
        Task<IReadOnlyCollection<Role>> FindRolesAsync(RoleFilter filters);
    }
}
