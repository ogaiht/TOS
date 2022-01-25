using Microsoft.IdentityModel.Tokens;

namespace TOS.Common.Security.Tokens.Factories
{
    public class EncryptingCredentialsFactory : IEncryptingCredentialsFactory
    {
        private readonly ISymmetricSecurityKeyFactory _symmetricSecurityKey;

        public EncryptingCredentialsFactory(ISymmetricSecurityKeyFactory symmetricSecurityKey)
        {
            _symmetricSecurityKey = symmetricSecurityKey;
        }

        public EncryptingCredentials CreateEncryptingCredentials(string key)
        {
            SymmetricSecurityKey symmetricSecurityKey = _symmetricSecurityKey.CreateSymmetricKey(key);
            return new EncryptingCredentials(symmetricSecurityKey, SecurityAlgorithms.Aes128KW,
                SecurityAlgorithms.Aes128CbcHmacSha256);
        }
    }
}
