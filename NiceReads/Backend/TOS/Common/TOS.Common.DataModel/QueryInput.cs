namespace TOS.Common.DataModel
{
    public class QueryInput : IQueryInput
    {
        public QueryInput(int offset = -1, int limit = -1, string sortBy = null, SortDirection sortDirection = SortDirection.Asc)
            : this(new Paging(offset, limit), new Sort(sortBy, sortDirection))
        {
        }

        public QueryInput(IPaging paging, ISort sort)
        {
            Paging = paging;
            Sort = sort;
        }

        public IPaging Paging { get; }
        public ISort Sort { get; }
    }
}