using Util;
using Xunit;

namespace Challenge3.Tests
{
    public class FabricTrackerTests
    {
        [Fact]
        public void AllOverlappingPieces_FromFile()
        {
            var claims = new FileParser("Files/claims.txt").ReadAllLines();
            var fabricClaims = FabricClaim.ParseAll(claims);

            Assert.Equal(104712, FabricTracker.TotalOverlap(fabricClaims));
        }

        [Fact]
        public void FindSingleNonOverlappingClaim_FromFile()
        {
            var claims = new FileParser("Files/claims.txt").ReadAllLines();
            var fabricClaims = FabricClaim.ParseAll(claims);

            Assert.Equal(0, FabricTracker.SingleNonOverlapping(fabricClaims));
        }
    }
}
