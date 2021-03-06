﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Challenge3
{
    public class FabricClaim
    {
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

            var claimedCoordinates = CalculatedClaimedCoordinates(offsetX, offsetY, width, height);

            return new FabricClaim(id, claimedCoordinates);
        }

        public int Id { get; }
        public IEnumerable<Coordinate> ClaimedCoordinates { get; }
        public int Size =>
            ClaimedCoordinates.Count();

        private static IEnumerable<Coordinate> CalculatedClaimedCoordinates(int offsetX, int offsetY, int width, int height)
        {
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    yield return new Coordinate(x + offsetX, y + offsetY);
        }

        private FabricClaim(int id, IEnumerable<Coordinate> claimedCoordinates)
        {
            Id = id;
            ClaimedCoordinates = claimedCoordinates;
        }
    }
}