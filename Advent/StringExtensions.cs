using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent
{
    public static class StringExtensions
    {
        public static bool ContainsSameLetter(this string input, int times)
        {
            return input
                .GroupBy(i => i)
                .Select(group => group.Count())
                .Any(t => t == times);

        }
    }
}
