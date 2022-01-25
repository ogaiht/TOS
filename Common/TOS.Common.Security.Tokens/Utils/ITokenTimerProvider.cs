using System;

namespace TOS.Common.Security.Tokens.Utils
{
    public interface ITokenTimerProvider
    {
        DateTime GetNotValidBefore(int tokenNotValidBeforeSeconds);
        int GetTokenExpirationInMinutes(DateTime expirationTime);
    }
}
