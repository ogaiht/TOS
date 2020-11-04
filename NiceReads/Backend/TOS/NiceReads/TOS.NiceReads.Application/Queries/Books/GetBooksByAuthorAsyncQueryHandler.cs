using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Books
{
    public class GetBooksByAuthorAsyncQueryHandler : IAsyncQueryHandler<GetBooksByAuthorAsyncQuery, IReadOnlyCollection<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksByAuthorAsyncQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IReadOnlyCollection<Book>> ExecuteAsync(GetBooksByAuthorAsyncQuery execution)
        {
            return await _bookRepository.GetByAuthorIdAsync(ObjectId.Parse(execution.AuthorId));
        }
    }
}
