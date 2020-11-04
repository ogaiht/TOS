using System.Threading.Tasks;
using TOS.NiceReads.Application.Commands.Authentications;

namespace TOS.NiceReads.Application.Services.Authentication
{
    public interface IAuthenticator
    {
        Task<AuthenticationResult> AuthenticateAsync(UserCredentials userCredentials);
    }
}
