namespace TOS.Common.Security.Cryptography
{
    public sealed class HashResult
    {
        public HashResult(byte[] hash, byte[] key)
        {
            Hash = hash;
            Key = key;
        }

        public byte[] Hash { get; }
        public byte[] Key { get; }
    }
}
