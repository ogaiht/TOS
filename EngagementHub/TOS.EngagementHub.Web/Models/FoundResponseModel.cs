namespace TOS.EngagementHub.Web.Models
{
    public class FoundResponseModel<T> : ResponseModel
    {
        public T Data { get; private set; }

        public FoundResponseModel(T data)
            : base(ResponseStatus.Found)
        {
            Data = data;
        }
    }
}
