using System.Collections.Generic;
using System.IO;
using System.Linq;
using Advent;
using Xunit;

namespace AdventTests
{
    public class Challenge1Tests
    {
        [Theory]
        [MemberData(nameof(FrequencyCases))]

        public void Frequency_Simple(int[] input, int result)
        {
            Assert.Equal(result, Calibrator.Calibrate(input));
        }

        [Fact]
        public void Frequency_FromFile()
        {
            List<int> input;
            using (var file = new StreamReader("Files/frequency_simple.txt"))
            {
                input = file.ReadAllLinesAsIntegers().ToList();
            }

            Assert.Equal(490, Calibrator.Calibrate(input));
        }

        public static IEnumerable<object[]> FrequencyCases()
        {
            yield return new object[]
            {
                new [] { 1, 1,1 }, 3
            };
            yield return new object[]
            {
                new [] {1, 1, -2}, 0
            };
            yield return new object[]
            {
                new [] {-1, -2, -3}, -6
            };
        }
    }
}
