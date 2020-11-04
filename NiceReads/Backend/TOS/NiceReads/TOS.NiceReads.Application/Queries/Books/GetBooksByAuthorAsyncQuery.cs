using System.Collections.Generic;
using TOS.CQRS.Executions.Queries;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Books
{
    public class GetBooksByAuthorAsyncQuery : AsyncQuery<IReadOnlyCollection<Book>>
    {
        public GetBooksByAuthorAsyncQuery(string authorId)
        {
            AuthorId = authorId;
        }

        public string AuthorId { get; }
    }
}
