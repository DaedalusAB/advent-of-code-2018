using System.Collections.Generic;
using System.IO;

namespace Advent
{
    public static class StreamReaderExtensions
    {
        public static IEnumerable<int> ReadAllLinesAsIntegers(this StreamReader stream)
        {
            var result = new List<int>();
            string line;

            while ((line = stream.ReadLine()) != null)
            {
                result.Add(int.Parse(line));
            }

            return result;
        }

        public static IEnumerable<string> ReadAllLines(this StreamReader stream)
        {
            var result = new List<string>();
            string line;

            while ((line = stream.ReadLine()) != null)
            {
                result.Add(line);
            }

            return result;
        }
    }
}
