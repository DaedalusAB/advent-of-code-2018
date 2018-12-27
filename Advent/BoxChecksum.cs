using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class BoxChecksum
    {
        public static int CalculateChecksum(IEnumerable<string> input)
        {
            var enumerable = input.ToList();
            return enumerable.Count(i => i.ContainsSameLetter(2)) * enumerable.Count(i => i.ContainsSameLetter(3));
        }

        public static string FindCommonIDs(string[] input)
        {
            throw new System.NotImplementedException();
        }
    }
}