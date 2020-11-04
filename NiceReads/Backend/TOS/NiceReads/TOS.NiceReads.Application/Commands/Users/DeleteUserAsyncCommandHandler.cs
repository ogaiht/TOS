using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Data.Repositories;

namespace TOS.NiceReads.Application.Commands.Users
{
    public class DeleteUserAsyncCommandHandler : IAsyncCommandHandler<DeleteUserAsyncCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserAsyncCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(DeleteUserAsyncCommand execution)
        {
            await _userRepository.DeleteAsync(ObjectId.Parse(execution.UserId));
        }
    }
}
