using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.Security.Models;

namespace TOS.Application.Security.Queries.Roles
{
    public class GetAllRolesAsyncQuery : AsyncQuery<IPagedResult<Role>>
    {
        public string SortBy { get; }
        public SortDirection SortDirection { get; }
        public int Offset { get; }
        public int Limit { get; }
        public GetAllRolesAsyncQuery(string sortBy = null, SortDirection sortDirection = SortDirection.Asc, int offset = -1, int limit = -1)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
            Offset = offset;
            Limit = limit;
        }
    }
}
