using System.Collections.Generic;

namespace Challenge3
{
    public class FabricPiece
    {
        public List<int> Claims { get; }
        public Coordinate Coordinate { get; }

        public FabricPiece(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
            Claims = new List<int>();
        }

        public void AddClaim(int id) =>
            Claims.Add(id);
    }
}
