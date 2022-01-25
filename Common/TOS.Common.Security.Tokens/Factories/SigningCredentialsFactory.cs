using Microsoft.IdentityModel.Tokens;

namespace TOS.Common.Security.Tokens.Factories
{
    public class SigningCredentialsFactory : ISigningCredentialsFactory
    {
        private readonly ISymmetricSecurityKeyFactory _symmetricSecurityKeyFactory;

        public SigningCredentialsFactory(ISymmetricSecurityKeyFactory symmetricSecurityKeyFactory)
        {
            _symmetricSecurityKeyFactory = symmetricSecurityKeyFactory;
        }

        public SigningCredentials CreateSigningCredentials(string key)
        {
            SymmetricSecurityKey symmetricSecurityKey = _symmetricSecurityKeyFactory.CreateSymmetricKey(key);
            return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
