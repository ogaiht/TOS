
namespace TOS.Common.Security.Cryptography
{
    public interface IHashGenerator
    {
        HashResult GenerateWithKey(byte[] value, byte[] key);

        HashResult GenerateWithNewRandomKey(byte[] value);
    }
}
