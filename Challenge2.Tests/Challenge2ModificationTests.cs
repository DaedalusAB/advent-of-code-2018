using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Util;
using Xunit;

namespace Challenge2.Tests
{
    public class Challenge2ModificationTests
    {

        [Theory]
        [InlineData("abcde", "fghji", false)]
        [InlineData("fghij", "fguij", true)]
        [InlineData("fghii", "fguij", false)]
        public void StringsHaveDifferenceOnSingleIndex(string input1, string input2, bool result)
        {
            Assert.Equal(result, input1.HasDifferenceOnSingleIndex(input2));
        }

        [Theory]
        [InlineData("fghij", "fguij", "fgij")]
        [InlineData("aghijf", "fguija", "gij")]
        [InlineData("fghij", "fguijxxx", "fgij")]
        public void RemoveAllDifferingCharsFromTwoStrings_ShouldCompareIndexWithIndex(string input1, string input2, string result)
        {
            Assert.Equal(result, input1.RemoveAllDifferingChars(input2));
        }

        [Theory]
        [MemberData(nameof(BoxesAdvancedCheksumCases))]
        public void BoxeChecksum_Advanced(string[] input, string common)
        {
            Assert.Equal(common, BoxChecksum.FindCommonIDs(input));
        }

        [Fact]
        public void BoxesCheksumFromFile_Advanced()
        {
            List<string> inputs;
            using (var file = new StreamReader("Files/boxes.txt"))
            {
                inputs = file.ReadAllLines().ToList();
            }

            Assert.Equal("krdmtuqjgwfoevnaboxglzjph", BoxChecksum.FindCommonIDs(inputs));
        }

        public static IEnumerable<object[]> BoxesAdvancedCheksumCases()
        {
            yield return new object[]
            {
                new [] { "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz" }, "fgij"
            };
        }
    }
}
