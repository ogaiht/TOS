using TOS.Common.Security;
using TOS.Common.Security.Cryptography;
using TOS.NiceReads.Models;

namespace TOS.NiceReads.Application.Utils
{
    public class PasswordUtils : IPasswordUtils
    {
        private readonly ITextHashHelper _textHashHelper;

        public PasswordUtils(ITextHashHelper textHashHelper)
        {
            _textHashHelper = textHashHelper;
        }

        public PasswordHash CreatePasswordHash(string password)
        {
             HashResult result = _textHashHelper.GenerateHash(password);
            return new PasswordHash()
            {
                Hash = result.Hash,
                Key = result.Key
            };
        }

        public bool ValidatedPassword(string password, PasswordHash passwordHash)
        {
            return _textHashHelper.ValidateHashesAreEqual(password, passwordHash.Hash, passwordHash.Key);
        }
    }
}
