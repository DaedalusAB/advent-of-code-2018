using System.Collections.Generic;
using System.IO;
using System.Linq;
using Util;
using Xunit;

namespace Challenge2.Tests
{
    public class Challenge2Tests
    {
        [Theory]
        [InlineData("abcdef", false)]
        [InlineData("bababc", true)]
        [InlineData("abbcde", true)]
        [InlineData("abcccd", false)]
        [InlineData("aabcdd", true)]
        [InlineData("abcdee", true)]
        [InlineData("ababab", false)]
        public void StringHasRepeatingLetter_ShouldReturnTrueIfAnyLetterRepeatsTwice(string input, bool repeatedLetter)
        {
            Assert.Equal(repeatedLetter, input.HasRepeatingLetter(2));
        }

        [Theory]
        [InlineData("abcdef", false)]
        [InlineData("bababc", true)]
        [InlineData("abbcde", false)]
        [InlineData("abcccd", true)]
        [InlineData("aabcdd", false)]
        [InlineData("abcdee", false)]
        [InlineData("ababab", true)]
        public void StringHasRepeatingLetter_ShouldReturnTrueIfAnyLetterRepeatsThrice(string input, bool repeatedLetter)
        {
            Assert.Equal(repeatedLetter, input.HasRepeatingLetter(3));
        }

        [Theory]
        [MemberData(nameof(BoxesCheksumCases))]
        public void CalculateChecksumOfBoxIds_Simple(string[] input, int checksum)
        {
            Assert.Equal(checksum, BoxChecksum.CalculateChecksum(input));
        }

        [Fact]
        public void CalculateChecksumOfBoxIdsFromFile_Simple()
        {
            var inputs = new FileParser("Files/boxes.txt").ReadAllLines();

            Assert.Equal(5952, BoxChecksum.CalculateChecksum(inputs));
        }

        public static IEnumerable<object[]> BoxesCheksumCases()
        {
            yield return new object[]
            {
                new [] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, 12
            };
        }
    }
}
