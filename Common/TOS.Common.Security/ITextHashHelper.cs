using TOS.Common.Security.Cryptography;

namespace TOS.Common.Security
{
    public interface ITextHashHelper
    {
        HashResult GenerateHash(string text);

        bool ValidateHashesAreEqual(string text, byte[] hashedText, byte[] key);
    }
}
