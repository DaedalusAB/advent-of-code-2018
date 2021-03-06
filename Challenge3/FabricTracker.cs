﻿using System.Collections.Generic;
using System.Linq;

namespace Challenge3
{
    public class FabricTracker
    {
        private const int Size = 1000;
        private readonly List<FabricClaim> _trackedClaims;
        private readonly FabricPiece[] _pieces;

        public FabricTracker()
        {
            _trackedClaims = new List<FabricClaim>();
            _pieces = new FabricPiece[Size * Size];
        }

        public int TotalOverlap =>
            _pieces
                .Where(p => p != null)
                .Count(p => p.Claims.Count > 1);

        public int SingleNonOverlappingClaim =>
            // ewwwwwww
            _pieces
                .Where(p => p?.Claims.Count == 1)
                .Select(p => p.Claims.First())
                .GroupBy(p => p)
                .Select(g => new { Id = g.Key, Size = g.Count() })
                .First(g => g.Size == _trackedClaims.Find(p => p.Id == g.Id).Size)
                .Id;
        
        public void TrackAll(IEnumerable<FabricClaim> fabricClaims)
        {
            foreach (var fabricClaim in fabricClaims)
            {
                TrackSingleClaim(fabricClaim);
            }
        }

        private void TrackSingleClaim(FabricClaim fabricClaim)
        {
            _trackedClaims.Add(fabricClaim);

            foreach (var claimedPiece in fabricClaim.ClaimedCoordinates)
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