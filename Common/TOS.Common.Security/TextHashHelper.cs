using TOS.Common.Security.Cryptography;
using TOS.Common.Text;

namespace TOS.Common.Security
{
    public class TextHashHelper : ITextHashHelper
    {
        private readonly IHashGenerator _hashGenerator;
        private readonly IEncodingHelper _encodingHelper;

        public TextHashHelper(IHashGenerator hashGenerator, IEncodingHelper encodingHelper)
        {
            _hashGenerator = hashGenerator;
            _encodingHelper = encodingHelper;
        }

        public HashResult GenerateHash(string text)
        {
            byte[] textBytes = _encodingHelper.GetUTF8Bytes(text);
            return _hashGenerator.GenerateWithNewRandomKey(textBytes);
        }

        public bool ValidateHashesAreEqual(string newText, byte[] hashedText, byte[] key)
        {
            byte[] newTextBytes = _encodingHelper.GetUTF8Bytes(newText);
            HashResult newTextHashResult = _hashGenerator.GenerateWithKey(newTextBytes, key);
            byte[] newTextHash = newTextHashResult.Hash;
            return CheckHashesAreEqual(hashedText, newTextHash);
        }

        private static bool CheckHashesAreEqual(byte[] hashedText, byte[] newTextHash)
        {
            if (newTextHash.Length != hashedText.Length)
            {
                return false;
            }
            for (int i = 0; i < newTextHash.Length; i++)
            {
                if (newTextHash[i] != hashedText[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
