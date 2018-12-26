using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> enumerable, int index = 0)
        {
            var count = enumerable.Count();
            index = index % count;

            while (true)
            {
                yield return enumerable.ElementAt(index);
                index = (index + 1) % count;
            }
        }
    }
}
