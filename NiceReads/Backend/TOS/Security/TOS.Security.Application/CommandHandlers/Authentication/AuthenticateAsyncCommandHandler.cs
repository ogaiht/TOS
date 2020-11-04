using System.Threading.Tasks;
using TOS.Application.Security.Commands.Authentication;
using TOS.Application.Security.Utils;
using TOS.Common;
using TOS.CQRS.Handlers.Commands;
using TOS.Data.Security.Repositories;
using TOS.Security.Models;

namespace TOS.Application.Security.CommandHandlers.Authentication
{
    public class AuthenticateAsyncCommandHandler : IAsyncCommandHandler<AuthenticateAsyncCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordUtils _passwordUtils;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AuthenticateAsyncCommandHandler(IUserRepository userRepository, IPasswordUtils passwordUtils, IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _passwordUtils = passwordUtils;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<AuthenticationResult> ExecuteAsync(AuthenticateAsyncCommand execution)
        {
            User user = await _userRepository.GetByUsername(execution.Username);
            if (user == null)
            {
                return new AuthenticationResult(AutheticationResultStatus.InvalidUser);
            }
            
            if (!_passwordUtils.ValidatedPassword(execution.Password, user.Password.Hash))
            {
                return new AuthenticationResult(AutheticationResultStatus.InvalidPassword);
            }

            if (!user.Active)
            {
                return new AuthenticationResult(AutheticationResultStatus.InactiveUser);
            }

            user.LastAccess = _dateTimeProvider.UtcNow();

            await _userRepository.UpdateAsync(user);

            return new AuthenticationResult(AutheticationResultStatus.Success);
        }
    }
}
