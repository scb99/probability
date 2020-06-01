using static System.Console;

namespace Probability
{
    static class Episode09
    {
        public static void DoIt()
        {
            WriteLine(WeightedInteger.Distribution(10, 0, 0, 11, 5).Histogram());
        }
    }
}