using System.Collections.Generic;

namespace TOS.Common.DataModel
{
    public class PagedResult<TResult> : IPagedResult<TResult>
    {
        public PagedResult(IReadOnlyCollection<TResult> items, long total, int offset, int limit)
        {
            Items = items;
            Total = total;
            Offset = offset;
            Limit = limit;
        }

        public IReadOnlyCollection<TResult> Items { get; }

        public long Total { get; }
        public int Offset { get; }
        public int Limit { get; }
    }
}
