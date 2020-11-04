using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.CQRS.Handlers.Queries;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Authors
{
    public class GetAuthorsAsyncQueryHandler : IAsyncQueryHandler<GetAuthorsAsyncQuery, IPagedResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorsAsyncQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IPagedResult<Author>> ExecuteAsync(GetAuthorsAsyncQuery execution)
        {
            return await _authorRepository.GetAsync();
        }
    }
}
