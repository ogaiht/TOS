namespace TOS.Common.DataModel
{
    public interface ISort
    {
        string Property { get; }
        SortDirection Direction { get; }
    }
}