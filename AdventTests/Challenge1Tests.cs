using Advent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [Theory]
        [MemberData(nameof(FrequencyRepeatCases))]
        public void Frequency_Repeating(int[] input, int result)
        {
            Assert.Equal(result, Calibrator.CalibrateWithRepeat(input));
        }

        [Fact]
        public void Frequency_FromFile()
        {
            List<int> input;
            using (var file = new StreamReader("Files/frequency.txt"))
            {
                input = file.ReadAllLinesAsIntegers().ToList();
            }

            Assert.Equal(490, Calibrator.Calibrate(input));
        }

        [Fact]
        public void Frequency_Repeating_FromFile()
        {
            List<int> input;
            using (var file = new StreamReader("Files/frequency.txt"))
            {
                input = file.ReadAllLinesAsIntegers().ToList();
            }

            Assert.Equal(70357, Calibrator.CalibrateWithRepeat(input));
        }

        public static IEnumerable<object[]> FrequencyCases()
        {
            yield return new object[]
            {
                new [] { 1, 1, 1 }, 3
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

        public static IEnumerable<object[]> FrequencyRepeatCases()
        {
            yield return new object[]
            {
                new [] { 1, -1 }, 0
            };
            yield return new object[]
            {
                new [] {3, 3, 4, -2, -4}, 10
            };
            yield return new object[]
            {
                new [] {7, 7, -2, -7, -4}, 14
            };
        }
    }
}
