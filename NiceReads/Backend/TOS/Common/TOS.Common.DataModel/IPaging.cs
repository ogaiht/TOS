namespace TOS.Common.DataModel
{
    public interface IPaging
    {
        int Limit { get; }
        int Offset { get; }
    }
}