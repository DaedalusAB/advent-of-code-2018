using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge3
{
    public class FabricPiece
    {
        public List<int> Claims { get; }
        public int X { get; }
        public int Y { get; }

        public FabricPiece(int x, int y)
        {
            X = x;
            Y = y;
            Claims = new List<int>();
        }

        public void AddClaim(int id) =>
            Claims.Add(id);
    }
}
