using Microsoft.IdentityModel.Tokens;

namespace TOS.Common.Security.Tokens.Factories
{
    public interface ISymmetricSecurityKeyFactory
    {
        SymmetricSecurityKey CreateSymmetricKey(string key);
    }
}