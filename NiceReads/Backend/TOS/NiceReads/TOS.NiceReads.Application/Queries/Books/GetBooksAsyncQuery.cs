using TOS.Common.DataModel;
using TOS.CQRS.Executions.Queries;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Books
{
    public class GetBooksAsyncQuery : AsyncQuery<IPagedResult<Book>>
    {
    }
}
