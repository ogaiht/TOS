namespace TOS.Common.Security.Tokens
{
    public interface ISecurityConfig
    {
        string TokenSigningSecurityKey { get; }

        string TokenEncryptionKey { get; }

        string Issuer { get; }

        string Audience { get; }

        int TokenLifetimeInMinutes { get; }

        int TokenIssuanceWindowInMinutes { get; }
    }
}
