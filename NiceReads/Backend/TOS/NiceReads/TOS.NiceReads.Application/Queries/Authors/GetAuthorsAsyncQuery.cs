using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Authors
{
    public class GetAuthorsAsyncQuery : AsyncQuery<IPagedResult<Author>>
    {
    }
}
