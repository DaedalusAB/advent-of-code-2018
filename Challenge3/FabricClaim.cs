using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge3
{
    public class FabricClaim
    {
        public int Id { get; }
        public IEnumerable<Coordinate> ClaimedPieces { get; }

        public static IEnumerable<FabricClaim> ParseAll(IEnumerable<string> claims) =>
            claims.Select(Parse);

        public static FabricClaim Parse(string claim)
        {
            var splitInput = Regex.Split(claim, @"\D+");

            var id = int.Parse(splitInput[1]);

            var offsetX = int.Parse(splitInput[2]);
            var offsetY = int.Parse(splitInput[3]);
            var width = int.Parse(splitInput[4]);
            var height = int.Parse(splitInput[5]);

            var claimedPieces = CalculateClaimedPieces(offsetX, offsetY, width, height);

            return  new FabricClaim(id, claimedPieces);
        }

        private static IEnumerable<Coordinate> CalculateClaimedPieces(int offsetX, int offsetY, int width, int height)
        {
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    yield return new Coordinate(x + offsetX, y + offsetY);
        }

        private FabricClaim(int id, IEnumerable<Coordinate> claimedPieces)
        {
            Id = id;
            ClaimedPieces = claimedPieces;
        }
    }
}