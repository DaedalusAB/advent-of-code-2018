using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Calibrator
    {
        public static int Calibrate(IEnumerable<int> input)
        {
            return input.Sum();
        }
    }
}