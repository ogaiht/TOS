using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.Security.Models;

namespace TOS.Application.Security.Queries.Roles
{
    public class GetRolesByNameAsyncQuery : AsyncQuery<IPagedResult<Role>>
    {
        public GetRolesByNameAsyncQuery(string searchName, int offset = -1, int limit = -1)
        {
            SearchName = searchName;
            Paging = new Paging(offset, limit);
        }

        public IPaging Paging { get; }
        public string SearchName { get;  }
    }
}
