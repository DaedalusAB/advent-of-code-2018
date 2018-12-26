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

        public static int CalibrateWithRepeat(IEnumerable<int> input)
        {
            var result = 0;
            var savedResults = new Dictionary<int, int>() { { result, result } };

            foreach (var i in input.Cycle())
            {
                result += i;
                
                if (savedResults.ContainsKey(result))
                    return result;

                savedResults.Add(result, result);
            }

            return result;
        }
    }
}