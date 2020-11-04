namespace TOS.Common.DataModel
{
    public class Paging : IPaging
    {
        public Paging(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        public int Offset { get; }
        public int Limit { get; }
    }
}
