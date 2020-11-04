using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Authors
{
    public class CreateAuthorAsyncCommand : AsyncCommand<string>
    {
        public CreateAuthorAsyncCommand(string firstName, string middleName, string lastName, string knownAs, string biography, string createdBy)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            KnownAs = knownAs;
            Biography = biography;
            CreatedBy = createdBy;
        }

        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string KnownAs { get; }
        public string Biography { get; }
        public string CreatedBy { get; }
    }
}
