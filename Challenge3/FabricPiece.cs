using System.Collections.Generic;
using System.Linq;

namespace Challenge3
{
    public class FabricPiece : ValueObject
    {
        public int X { get; }
        public int Y { get; }

        public FabricPiece(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return X;
            yield return Y;
        }
    }
}
