namespace TOS.NiceReads.Application.Commands.Authentications
{
    public enum AuthenticationStatus
    {
        Success,
        InvalidUser,
        InvalidPassword,
        InactiveUser,
        Blocked,
        ExpiredPassword
    }
}
