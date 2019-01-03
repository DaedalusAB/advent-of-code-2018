using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Challenge3.Tests
{
    public class FabricClaimTests
    {
        [Theory]
        [MemberData(nameof(ClaimsAsStrings))]
        public void ParseClaimFromString(string claim, int expectedId, IEnumerable<Coordinate> expectedClaimedPieces)
        {
            var fabrifClaim = FabricClaim.Parse(claim);

            Assert.Equal(expectedId, fabrifClaim.Id);
            Assert.True(fabrifClaim.ClaimedPieces.SequenceEqual(expectedClaimedPieces));
        }

        public static IEnumerable<object[]> ClaimsAsStrings()
        {
            yield return new object[]
            {
                "#1 @ 0,0 2,2",
                1,
                new [] { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 0), new Coordinate(1, 1) }
            };
        }
    }
}
