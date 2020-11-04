using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Data.Repositories;

namespace TOS.NiceReads.Application.Commands.Authors
{
    public class DeleteAuthorAsyncCommandHandler : IAsyncCommandHandler<DeleteAuthorAsyncCommand>
    {
        private readonly IAuthorRepository _authorRepository;

        public DeleteAuthorAsyncCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task ExecuteAsync(DeleteAuthorAsyncCommand execution)
        {
            ObjectId authorId = ObjectId.Parse(execution.AuthorId);
            await _authorRepository.DeleteAsync(authorId);
        }
    }
}
