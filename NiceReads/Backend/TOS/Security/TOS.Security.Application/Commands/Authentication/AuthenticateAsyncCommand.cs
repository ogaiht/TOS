using TOS.CQRS.Executions.Commands;

namespace TOS.Application.Security.Commands.Authentication
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

    public class AuthenticationResult
    {
        public AuthenticationResult(AutheticationResultStatus status)
        {
            Status = status;
        }

        public AutheticationResultStatus Status { get; }
    }

    public enum AutheticationResultStatus
    {
        Success,
        InvalidUser,
        InvalidPassword,
        InactiveUser,
        Blocked,
        ExpiredPassword
    }
}
