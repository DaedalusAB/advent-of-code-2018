using System.Collections.Generic;
using System.Linq;

namespace Challenge3
{
    public class FabricTracker
    {
        private static readonly int Size = 1000;
        
        public static int TotalOverlap(IEnumerable<FabricClaim> fabricClaims)
        {
            var pieces = new FabricPiece[Size * Size];

            foreach (var fabricClaim in fabricClaims)
            {
                foreach (var claimedPiece in fabricClaim.ClaimedPieces)
                {
                    var position = claimedPiece.X * Size + claimedPiece.Y;

                    if (pieces[position] == null)
                    {
                        pieces[position] = new FabricPiece(claimedPiece.X, claimedPiece.Y);
                    }

                    pieces[position].AddClaim(fabricClaim.Id);
                }
            }

            return pieces
                .Where(p => p != null)
                .Count(p => p.Claims.Count > 1);
        }

        public static int SingleNonOverlapping(IEnumerable<FabricClaim> fabricClaims)
        {
            return 0;
        }

    }
}