namespace TOS.Common.DataModel
{
    public class Sort : ISort
    {
        public Sort(string property, SortDirection direction)
        {
            Property = property;
            Direction = direction;
        }

        public string Property { get; }

        public SortDirection Direction { get; }
    }
}