using TOS.CQRS.Executions.Queries;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Authors
{
    public class GetAuthorByIdAsyncQuery : AsyncQuery<Author>
    {
        public GetAuthorByIdAsyncQuery(string authorId)
        {
            AuthorId = authorId;
        }

        public string AuthorId { get; }
    }
}
