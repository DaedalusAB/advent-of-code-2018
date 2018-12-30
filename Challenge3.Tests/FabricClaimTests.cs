using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Challenge3.Tests
{
    public class FabricClaimTests
    {
        [Theory]
        [MemberData(nameof(ParseFabricClaimCases))]
        public void ParseFabricClaimFromString_Should(string claim, int expectedId, IEnumerable<FabricPiece> expectedPieces)
        {
            var fabricClaim = FabricClaim.Parse(claim);

            Assert.Equal(expectedId, fabricClaim.Id);
            Assert.True(fabricClaim.ClaimedPieces.SequenceEqual(expectedPieces));
        }

        [Theory]
        [MemberData(nameof(OverlappingFabricCases))]
        public void TwoOverlapingClaims_ShouldReturnAllSharedFabricPieces(string claim1, string claim2, IEnumerable<FabricPiece> expectedSharedPieces)
        {
            var fabricClaim1 = FabricClaim.Parse(claim1);
            var fabricClaim2 = FabricClaim.Parse(claim2);

            Assert.True(fabricClaim1.GetOverlappingPiecesWith(fabricClaim2).SequenceEqual(expectedSharedPieces));
        }

        public static IEnumerable<object[]> ParseFabricClaimCases()
        {
            yield return new object[]
            {
                "#15 @ 1,2: 2,1",
                15,
                new List<FabricPiece>()
                {
                    new FabricPiece(1, 2),
                    new FabricPiece(2, 2)
                }
            };

            yield return new object[]
            {
                "#14 @ 0,0 1,2",
                14,
                new List<FabricPiece>()
                {
                    new FabricPiece(0, 0),
                    new FabricPiece(0, 1)
                }
            };
        }

        public static IEnumerable<object[]> OverlappingFabricCases()
        {
            yield return new object[]
            {
                "#1 @ 0,0 2,2",
                "#2 @ 1,1 2,2",
                new List<FabricPiece>()
                {
                    new FabricPiece(1, 1)
                }
            };
        }
    }
}
