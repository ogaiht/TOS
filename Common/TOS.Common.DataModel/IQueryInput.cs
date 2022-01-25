namespace TOS.Common.DataModel
{
    public interface IQueryInput
    {
        IPaging Paging { get; }
        ISort Sort { get; }
    }
}