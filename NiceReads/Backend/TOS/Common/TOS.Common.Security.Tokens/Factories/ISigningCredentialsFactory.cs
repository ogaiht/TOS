using Microsoft.IdentityModel.Tokens;

namespace TOS.Common.Security.Tokens.Factories
{
    public interface ISigningCredentialsFactory
    {
        SigningCredentials CreateSigningCredentials(string key);
    }
}