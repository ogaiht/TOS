using System;
using System.Collections.Generic;

namespace TOS.Common.Collections
{
    public static class EnumerableExtensions
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> items, Action<TItem> action)
        {
            foreach (TItem item in items)
            {
                action(item);
            }
        }
    }
}
