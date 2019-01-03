using System.Collections.Generic;
using System.Linq;

namespace Challenge3
{
    public class FabricTracker
    {
        private static readonly int Size = 1000;
        private FabricPiece[] _pieces;
        private Dictionary<int, bool> _overlapMap;

        public FabricTracker()
        {
            _pieces = new FabricPiece[Size * Size];
            _overlapMap = new Dictionary<int, bool>();
        }

        public int TotalOverlap =>
            _pieces
                .Where(p => p != null)
                .Count(p => p.Claims.Count > 1);

        public int SingleNonOverlappingClaim =>
            0;

        public void TrackAll(IEnumerable<FabricClaim> fabricClaims)
        {
            foreach (var fabricClaim in fabricClaims)
            {
                TrackSingleClaim(fabricClaim);
            }
        }

        private void TrackSingleClaim(FabricClaim fabricClaim)
        {
            foreach (var claimedPiece in fabricClaim.ClaimedPieces)
            {
                var position = claimedPiece.X * Size + claimedPiece.Y;

                if (_pieces[position] == null)
                {
                    _pieces[position] = new FabricPiece(claimedPiece.X, claimedPiece.Y);
                }

                _pieces[position].AddClaim(fabricClaim.Id);
            }
        }

    }
}