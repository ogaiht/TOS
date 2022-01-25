namespace TOS.Common.Security.Tokens
{
    public class TokenResult
    {
        public TokenResult(string token, int timeInSecondsUntilNewTokenIssuance)
        {
            Token = token;
            TimeInSecondsUntilNewTokenIssuance = timeInSecondsUntilNewTokenIssuance;
        }

        public string Token { get; }
        public int TimeInSecondsUntilNewTokenIssuance { get; }
    }
}
