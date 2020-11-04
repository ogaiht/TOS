namespace TOS.Security.Models
{
    public class PasswordHash
    {
        public byte[] Hash { get; set; }
        public byte[] Key { get; set; }
    }

}
