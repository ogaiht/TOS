using System.Collections.Generic;

namespace TOS.Common.DataModel
{
    public class PagedResult<T> : IPagedResult<T>
    {
        public PagedResult(IReadOnlyCollection<T> items, long total)
        {
            Items = items;
            Total = total;
        }

        public IReadOnlyCollection<T> Items { get; }

        public long Total { get; }
    }
}
