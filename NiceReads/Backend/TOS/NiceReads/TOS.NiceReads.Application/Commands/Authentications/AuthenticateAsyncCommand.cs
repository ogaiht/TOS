using TOS.CQRS.Executions.Commands;

namespace TOS.NiceReads.Application.Commands.Authentications
{
    public class AuthenticateAsyncCommand : AsyncCommand<AuthenticationResult>
    {
        public AuthenticateAsyncCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}
