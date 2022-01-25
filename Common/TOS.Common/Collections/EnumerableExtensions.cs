using System;
using System.Collections.Generic;
using System.Linq;

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

        public static IReadOnlyCollection<TItem> Remove<TItem>(this ICollection<TItem> collection, Predicate<TItem> predicate)
        {
            List<TItem> removedItems = new List<TItem>();
            foreach (TItem item in collection.ToArray())
            {
                if (predicate(item))
                {
                    collection.Remove(item);
                    removedItems.Add(item);
                }
            }
            return removedItems.ToArray();
        }
    }
}
