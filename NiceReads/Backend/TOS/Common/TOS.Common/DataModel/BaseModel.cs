namespace TOS.Common.DataModel
{
    public abstract class BaseModel<TId> : IBasedModel<TId>
    {
        public virtual TId Id { get; set; }
    }
}
