using MongoDB.Bson;
using System.Threading.Tasks;
using TOS.NiceReads.Application.Commands.Authentications;
using TOS.NiceReads.Application.Utils;
using TOS.NiceReads.Data.Repositories;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Services.Authentication
{
    public class Authenticator : IAuthenticator
    {
        private readonly IUserRepository _userRepository;        
        private readonly IPasswordUtils _passwordUtils;

        public Authenticator(IUserRepository userRepository, IPasswordUtils passwordUtils)
        {
            _userRepository = userRepository;
            _passwordUtils = passwordUtils;
        }

        public async Task<AuthenticationResult> AuthenticateAsync(UserCredentials userCredentials)
        {
            User user = await _userRepository.GetByUsernameAsync(userCredentials.Username);
            if (user == null)
            {
                return new AuthenticationResult(AuthenticationStatus.InvalidUser, null);
            }

            UserInfo userInfo = new UserInfo(user.Id, user.Username, user.Email);

            if (!_passwordUtils.ValidatedPassword(userCredentials.Password, user.Password.Hash))
            {
                return new AuthenticationResult(AuthenticationStatus.InvalidPassword, userInfo);
            }

            if (!user.Active)
            {
                return new AuthenticationResult(AuthenticationStatus.InactiveUser, userInfo);
            }

            return new AuthenticationResult(AuthenticationStatus.Success, userInfo);
        }
    }
}
