namespace TOS.Common.DataModel
{
    public interface IBasedModel<TId>
    {
        TId Id { get; set; }
    }
}
