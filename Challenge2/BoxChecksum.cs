using System.Collections.Generic;
using System.Linq;

namespace Challenge2
{
    public class BoxChecksum
    {
        public static int CalculateChecksum(IEnumerable<string> input)
        {
            var enumerable = input.ToList();
            return enumerable.Count(i => i.ContainsSameLetter(2)) * enumerable.Count(i => i.ContainsSameLetter(3));
        }

        public static IEnumerable<char> FindCommonIDs(IEnumerable<string> inputs)
        {
            foreach (var input in inputs)
            {
                var similarId = inputs.FirstOrDefault(i => i.DiffersOnSingleIndex(input));
                if (similarId != null)
                {
                    return similarId.RemoveAllDifferingChars(input);
                }
            }

            return null;
        }
    }
}