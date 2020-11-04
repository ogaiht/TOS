using System.Security.Cryptography;
using TOS.Common.Utils;

namespace TOS.Common.Security.Cryptography.HMACSHA_512
{
    public class HMACSHA512HashGenerator : IHashGenerator
    {
        private readonly IExceptionHelper _exceptionHelper;

        public HMACSHA512HashGenerator(IExceptionHelper exceptionHelper)
        {
            _exceptionHelper = exceptionHelper;
        }

        public HashResult GenerateWithKey(byte[] value, byte[] key)
        {
            _exceptionHelper.CheckArgumentNullException(value, nameof(value));
            ValidateSalt(key);
            return GenerateHash(value, key);
        }

        public HashResult GenerateWithNewRandomKey(byte[] value)
        {
            _exceptionHelper.CheckArgumentNullException(value, nameof(value));
            return GenerateHash(value, null);
        }

        private static HashResult GenerateHash(byte[] value, byte[] key)
        {
            using HMACSHA512 hmac = (key != null
                ? new HMACSHA512(key)
                : new HMACSHA512());
            byte[] hash = hmac.ComputeHash(value);
            return new HashResult(hash, hmac.Key);
        }

        private void ValidateSalt(byte[] salt)
        {
            _exceptionHelper.CheckArgumentNullException(salt, nameof(salt));
            _exceptionHelper.CheckArgumentException(salt.Length != 128, "Invalid length of password salt(128 bytes expected).", nameof(salt));
        }
    }
}
