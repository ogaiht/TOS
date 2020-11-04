using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Users
{
    public class GetUsersAsyncQuery : AsyncQuery<IPagedResult<User>>
    {

    }
}
