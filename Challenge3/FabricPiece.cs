using System.Collections.Generic;

namespace Challenge3
{
    public class FabricPiece : ValueObject
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

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Claims;
            yield return Coordinate;
        }
    }
}
