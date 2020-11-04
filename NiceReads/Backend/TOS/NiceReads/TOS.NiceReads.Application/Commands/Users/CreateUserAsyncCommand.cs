using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Users
{
    public class CreateUserAsyncCommand : AsyncCommand<CreateUserAsyncCommandResult>
    {
        public CreateUserAsyncCommand(string username, string firstName, string lastName, string email, string password)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public string Username { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
    }
}
