using System;

namespace Probability
{
    static class Episode07
    {
        public static void DoIt()
        {
            Console.WriteLine("Episode 07");
            Console.WriteLine();

            Console.WriteLine(WeightedInteger.Distribution(10, 11, 5).Histogram());
            Console.WriteLine();
        }
    }
}