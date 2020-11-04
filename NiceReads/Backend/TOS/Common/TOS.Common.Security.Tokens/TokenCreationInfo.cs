using System;

namespace TOS.Common.Security.Tokens
{
    public class TokenCreationInfo
    {
        public TokenCreationInfo(string id, string username, string email, DateTime expiresAt)
        {
            Id = id;
            Username = username;
            Email = email;
            ExpiresAt = expiresAt;
        }

        public string Id { get; }
        public string Username { get; }
        public string Email { get; }
        public DateTime ExpiresAt { get; }
    }
}
