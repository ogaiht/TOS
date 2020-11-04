using System.Threading.Tasks;
using TOS.CQRS.Handlers.Commands;
using TOS.NiceReads.Application.Services.Authentication;
using TOS.NiceReads.Application.Services.Logins;

namespace TOS.NiceReads.Application.Commands.Authentications
{
    public class AuthenticateAsyncCommandHandler : IAsyncCommandHandler<AuthenticateAsyncCommand, AuthenticationResult>
    {
        private readonly IAuthenticator _authenticator;
        private readonly ILoginHistoryManager _loginHistoryManager;

        public AuthenticateAsyncCommandHandler(IAuthenticator authenticator, ILoginHistoryManager loginHistoryManager)
        {
            _authenticator = authenticator;
            _loginHistoryManager = loginHistoryManager;
        }

        public async Task<AuthenticationResult> ExecuteAsync(AuthenticateAsyncCommand execution)
        {
            AuthenticationResult result = await _authenticator.AuthenticateAsync(new UserCredentials(execution.Username, execution.Password));
            if (result.Status != AuthenticationStatus.InvalidUser)
            {
                await _loginHistoryManager.RecoredLoginAsync(result.UserInfo.Id, result.Status);
            }
            return result;
        }
    }
}
