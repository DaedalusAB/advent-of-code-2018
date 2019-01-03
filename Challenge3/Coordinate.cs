using System.Collections.Generic;

namespace Challenge3
{
    public class Coordinate : ValueObject
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
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
