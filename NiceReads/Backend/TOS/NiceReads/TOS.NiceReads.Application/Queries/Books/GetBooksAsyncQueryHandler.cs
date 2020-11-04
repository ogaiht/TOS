using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Books
{
    public class GetBooksAsyncQueryHandler : IAsyncQueryHandler<GetBooksAsyncQuery, IPagedResult<Book>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksAsyncQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IPagedResult<Book>> ExecuteAsync(GetBooksAsyncQuery execution)
        {
            return await _bookRepository.GetBooksAsync();
        }
    }
}
