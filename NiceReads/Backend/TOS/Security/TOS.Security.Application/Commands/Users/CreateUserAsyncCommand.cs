using TOS.CQRS.Executions.Commands;

namespace TOS.Application.Security.Commands.Users
{
    public class CreateUserAsyncCommand : AsyncCommand<string>
    {
        public CreateUserAsyncCommand(string username, string password, string email, string firstname, string lastname)
        {
            Username = username;
            Password = password;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Username { get; }
        public string Password { get; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
