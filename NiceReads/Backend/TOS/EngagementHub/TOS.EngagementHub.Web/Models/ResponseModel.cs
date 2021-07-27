namespace TOS.EngagementHub.Web.Models
{
    public class ResponseModel
    {
        public ResponseModel(ResponseStatus status)
        {
            Status = status;
        }

        public ResponseStatus Status { get; private set; }
    }
}
