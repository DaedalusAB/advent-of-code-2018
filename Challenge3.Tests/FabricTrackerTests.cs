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

            var tracker = new FabricTracker();
            tracker.TrackAll(fabricClaims);

            Assert.Equal(104712, tracker.TotalOverlap);
        }

        [Fact]
        public void FindSingleNonOverlappingClaim_FromFile()
        {
            var claims = new FileParser("Files/claims.txt").ReadAllLines();
            var fabricClaims = FabricClaim.ParseAll(claims);

            var tracker = new FabricTracker();
            tracker.TrackAll(fabricClaims);

            Assert.Equal(840, tracker.SingleNonOverlappingClaim());
        }
    }
}
