
using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Authors
{
    public class UpdateAuthorAsyncCommand : AsyncCommand
    {
        public UpdateAuthorAsyncCommand(string authorId, string firstName, string middleName, string lastName, string knownAs, string biography, string updatedBy)
        {
            AuthorId = authorId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            KnownAs = knownAs;
            Biography = biography;
            UpdatedBy = updatedBy;
        }
        public string AuthorId { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string KnownAs { get; }
        public string Biography { get; }
        public string UpdatedBy { get; }
    }
}
