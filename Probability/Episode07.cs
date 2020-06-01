using static System.Console;

namespace Probability
{
    static class Episode07
    {
        public static void DoIt()
        {
            WriteLine("Episode 07");
            WriteLine();

            WriteLine(WeightedInteger.Distribution(10, 11, 5).Histogram());
            WriteLine();
        }
    }
}