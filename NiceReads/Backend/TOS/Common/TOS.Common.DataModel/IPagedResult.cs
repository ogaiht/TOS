using System.Collections.Generic;

namespace TOS.Common.DataModel
{
    public interface IPagedResult<T>
    {
        IReadOnlyCollection<T> Items { get; }
        long Total { get; }
        int Offset { get; }
        int Limit { get; }
    }
}