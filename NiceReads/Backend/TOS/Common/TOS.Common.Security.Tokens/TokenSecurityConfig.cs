namespace TOS.Common.Security.Tokens
{
    public class TokenSecurityConfig : ISecurityConfig
    {
        public string TokenSigningSecurityKey { get; set; }

        public string TokenEncryptionKey { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int TokenLifetimeInMinutes { get; set; }

        public int TokenIssuanceWindowInMinutes { get; set; }
    }
}
