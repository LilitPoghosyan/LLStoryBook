using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryBook
{
    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }

        public static void AddRange<T>(this ICollection<T> items, IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                items.Add(item);
            }
        }
    }
}
