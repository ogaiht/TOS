namespace TOS.NiceReads.Application.Commands.Users
{
    public class CreateUserAsyncCommandResult
    {
        public CreateUserAsyncCommandResult(string userId = null, string invalidationMessage = null)
        {
            UserId = userId;
            Success = !string.IsNullOrEmpty(userId);
            Message = invalidationMessage;
        }

        public string UserId { get; }
        public bool Success { get; }
        public string Message { get; }
    }
}
