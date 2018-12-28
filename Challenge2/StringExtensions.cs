using System.Collections.Generic;
using System.Linq;

namespace Challenge2
{
    public static class StringExtensions
    {
        public static bool HasRepeatingLetter(this string input, int timesRepeated) =>
            input
                .GroupBy(letter => letter)
                .Select(group => group.Count())
                .Any(letterRepetitions => letterRepetitions == timesRepeated);

        public static bool HasDifferenceOnSingleIndex(this string input, string other) =>
            input
                .Zip(other, (i, o) => i == o)
                .Count(t => !t) == 1;

        public static IEnumerable<char> RemoveAllDifferingChars(this string input, string other) =>
            input
                .Zip(other, (i, o) => new { Original = i, Other = o })
                .Where(pairs => pairs.Original == pairs.Other)
                .Select(samePairs => samePairs.Original);
    }
}
