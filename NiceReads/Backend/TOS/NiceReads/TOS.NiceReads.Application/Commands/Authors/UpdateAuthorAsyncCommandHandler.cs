using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Common;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Commands.Authors
{
    public class UpdateAuthorAsyncCommandHandler : IAsyncCommandHandler<UpdateAuthorAsyncCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserRepository _userRepository;

        public UpdateAuthorAsyncCommandHandler(IAuthorRepository authorRepository, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
        {
            _authorRepository = authorRepository;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task ExecuteAsync(UpdateAuthorAsyncCommand execution)
        {
            ObjectId userId = await _userRepository.GetUserIdByUsernameAsync(execution.UpdatedBy);
            Author author = await _authorRepository.GetByIdAsync(ObjectId.Parse(execution.AuthorId));
            author.Biography = execution.Biography;
            author.FirstName = execution.FirstName;
            author.LastName = execution.LastName;
            author.MiddleName = execution.MiddleName;
            author.KnownAs = execution.KnownAs;
            author.UpdatedAt = _dateTimeProvider.UtcNow();
            author.UpdatedBy = userId;
            await _authorRepository.UpdateAsync(author);
        }
    }
}
