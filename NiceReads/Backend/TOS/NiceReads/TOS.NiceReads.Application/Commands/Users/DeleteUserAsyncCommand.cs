using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Users
{
    public class DeleteUserAsyncCommand : AsyncCommand
    {
        public DeleteUserAsyncCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
