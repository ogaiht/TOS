namespace TOS.NiceReads.Application.Commands.Authentications
{
    public class AuthenticationResult
    {
        public AuthenticationResult(AuthenticationStatus status, UserInfo userInfo)
        {
            Status = status;
            UserInfo = userInfo;
        }

        public AuthenticationStatus Status { get; }
        public UserInfo UserInfo { get; }
    }
}
