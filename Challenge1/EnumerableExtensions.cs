using System.Collections.Generic;
using System.Linq;

namespace Challenge1
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Cycle<T>(this IEnumerable<T> enumerable)
        {
            var count = enumerable.Count();
            var index = 0;

            while (true)
            {
                yield return enumerable.ElementAt(index);
                index = (index + 1) % count;
            }
        }
    }
}
