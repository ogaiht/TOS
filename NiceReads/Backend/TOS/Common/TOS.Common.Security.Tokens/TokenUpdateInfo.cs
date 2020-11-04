using System;
using System.Security.Claims;

namespace TOS.Common.Security.Tokens
{
    public class TokenUpdateInfo
    {
        public TokenUpdateInfo(ClaimsPrincipal claimsPrincipal, DateTime expiresAt, int tokenNotValidBeforeSeconds = 0)
        {
            ClaimsPrincipal = claimsPrincipal;
            ExpiresAt = expiresAt;
            TokenNotValidBeforeSeconds = tokenNotValidBeforeSeconds;
        }

        public ClaimsPrincipal ClaimsPrincipal { get; }
        public DateTime ExpiresAt { get; }
        public int TokenNotValidBeforeSeconds { get; }
    }
}
