using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Queries;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Queries.Authors
{
    public class GetAuthorByIdAsyncQueryHandler : IAsyncQueryHandler<GetAuthorByIdAsyncQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByIdAsyncQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> ExecuteAsync(GetAuthorByIdAsyncQuery execution)
        {
            return await _authorRepository.GetByIdAsync(ObjectId.Parse(execution.AuthorId));
        }
    }
}
