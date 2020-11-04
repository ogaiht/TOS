using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Authors
{
    public class DeleteAuthorAsyncCommand : AsyncCommand
    {
        public DeleteAuthorAsyncCommand(string authorId)
        {
            AuthorId = authorId;
        }

        public string AuthorId { get; }
    }
}
