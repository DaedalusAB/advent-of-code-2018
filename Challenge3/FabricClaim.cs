using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge3
{
    public class FabricClaim
    {
        public static FabricClaim Parse(string input)
        {
            var splitInput = Regex.Split(input, @"\D+");

            var id = int.Parse(splitInput[1]);

            var offsetX = int.Parse(splitInput[2]);
            var offsetY = int.Parse(splitInput[3]);
            var width = int.Parse(splitInput[4]);
            var height = int.Parse(splitInput[5]);

            var pieces = CalculateClaimedFabric(offsetX, offsetY, width, height);

            return new FabricClaim(id, pieces);
        }

        public int Id { get; }
        public HashSet<FabricPiece> ClaimedPieces { get; }

        private static HashSet<FabricPiece> CalculateClaimedFabric(int offsetX, int offsetY, int width, int height)
        {
            var pieces = new HashSet<FabricPiece>();

            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                pieces.Add(new FabricPiece(offsetX + x, offsetY + y));

            return pieces;
        }

        private FabricClaim(int id, HashSet<FabricPiece> claimedPieces)
        {
            Id = id;
            ClaimedPieces = claimedPieces;
        }

        public IEnumerable<FabricPiece> GetOverlappingPiecesWith(FabricClaim otherClaim) =>
            ClaimedPieces.Intersect(otherClaim.ClaimedPieces);
        
    }
}