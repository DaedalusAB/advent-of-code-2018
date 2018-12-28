using System.Collections.Generic;
using System.Linq;

namespace Challenge2
{
    public static class StringExtensions
    {
        public static bool ContainsSameLetter(this string input, int times) =>
            input
                .GroupBy(i => i)
                .Select(group => @group.Count())
                .Any(t => t == times);

        public static bool DiffersOnSingleIndex(this string input, string other) =>
            input
                .Zip(other, (i, o) => i == o)
                .Count(t => !t) == 1;

        public static IEnumerable<char> RemoveAllDifferingChars(this string input, string other) =>
            input
                .Zip(other, (i, o) => new { Original = i, Other = o })
                .Where(t => t.Original == t.Other)
                .Select(t => t.Original);
    }
}
