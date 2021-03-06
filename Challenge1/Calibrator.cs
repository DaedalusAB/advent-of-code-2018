using System.Collections.Generic;
using System.Linq;

namespace Challenge1
{
    public class Calibrator
    {
        public static int Calibrate(IEnumerable<int> input) => 
            input.Sum();

        public static int CalibrateWithRepeat(IEnumerable<int> input)
        {
            var result = 0;
            var savedResults = new HashSet<int>() { result };

            foreach (var i in input.Cycle())
            {
                result += i;
                
                if (savedResults.Contains(result))
                    return result;

                savedResults.Add(result);
            }

            return result;
        }
    }
}