﻿using Advent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventTests
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
        public void StringContainsExactlyTwoSameLetters(string input, bool containsLetterRepeatedTwice)
        {
            Assert.Equal(containsLetterRepeatedTwice, input.ContainsSameLetter(2));
        }

        [Theory]
        [InlineData("abcdef", false)]
        [InlineData("bababc", true)]
        [InlineData("abbcde", false)]
        [InlineData("abcccd", true)]
        [InlineData("aabcdd", false)]
        [InlineData("abcdee", false)]
        [InlineData("ababab", true)]
        public void StringContainsExactlyThreeSameLetters(string input, bool containsLetterRepeatedTwice)
        {
            Assert.Equal(containsLetterRepeatedTwice, input.ContainsSameLetter(3));
        }

        [Theory]
        [MemberData(nameof(BoxesCheksumCases))]
        public void BoxesChecksum_Simple(string[] input, int checksum)
        {
            Assert.Equal(checksum, BoxChecksum.CalculateChecksum(input));
        }

        [Fact]
        public void BoxesCheksumFromFile_Simple()
        {
            List<string> inputs;
            using (var file = new StreamReader("Files/boxes.txt"))
            {
                inputs = file.ReadAllLines().ToList();
            }


            Assert.Equal(5952, BoxChecksum.CalculateChecksum(inputs));
        }

        [Theory]
        [InlineData("abcde", "fghji", false)]
        [InlineData("fghij", "fguij", true)]
        [InlineData("fghii", "fguij", false)]
        public void StringsDifferOnOnlyOneIndex(string input1, string input2, bool result)
        {
            Assert.Equal(result, input1.DiffersOnSingleIndex(input2));
        }

        [Theory]
        [InlineData("fghij", "fguij", "fgij")]
        [InlineData("aghijf", "fguija", "gij")]
        [InlineData("fghij", "fguijxxx", "fgij")]
        public void RemoveAllDifferingChars(string input1, string input2, string result)
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

        public static IEnumerable<object[]> BoxesCheksumCases()
        {
            yield return new object[]
            {
                new [] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, 12
            };
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
