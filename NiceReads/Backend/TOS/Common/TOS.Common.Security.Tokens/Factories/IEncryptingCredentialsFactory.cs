using Microsoft.IdentityModel.Tokens;

namespace TOS.Common.Security.Tokens.Factories
{
    public interface IEncryptingCredentialsFactory
    {
        EncryptingCredentials CreateEncryptingCredentials(string key);
    }
}