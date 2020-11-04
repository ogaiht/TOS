using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.Common;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Commands.Authors
{
    public class CreateAuthorAsyncCommandHandler : IAsyncCommandHandler<CreateAuthorAsyncCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreateAuthorAsyncCommandHandler(IAuthorRepository authorRepository, IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
        {
            _authorRepository = authorRepository;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<string> ExecuteAsync(CreateAuthorAsyncCommand execution)
        {
            ObjectId userId = await _userRepository.GetUserIdByUsernameAsync(execution.CreatedBy);
            Author author = new Author()
            {
                FirstName = execution.FirstName,
                MiddleName = execution.MiddleName,
                LastName = execution.LastName,
                KnownAs = execution.KnownAs,
                Biography = execution.Biography,
                CreatedBy = userId,
                CreatedAt = _dateTimeProvider.UtcNow()
            };
            ObjectId authorId = await _authorRepository.AddAsync(author);
            return authorId.ToString();
        }
    }
}
