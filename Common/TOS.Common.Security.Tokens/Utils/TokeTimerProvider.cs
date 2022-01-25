using System;

namespace TOS.Common.Security.Tokens.Utils
{
    public class TokeTimerProvider : ITokenTimerProvider
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public TokeTimerProvider(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public DateTime GetNotValidBefore(int tokenNotValidBeforeSeconds)
        {
            DateTime utcNow = this._dateTimeProvider.UtcNow();
            return tokenNotValidBeforeSeconds == 0
                ? utcNow
                : utcNow.AddSeconds(tokenNotValidBeforeSeconds);
        }

        public int GetTokenExpirationInMinutes(DateTime expirationTime)
        {
            int tokenExpirationInMinutes = Convert.ToInt32((expirationTime - _dateTimeProvider.UtcNow()).TotalMinutes);
            return tokenExpirationInMinutes;
        }
    }
}
