using System.Linq;
using static System.Console;

namespace Probability
{
    using SDU = StandardDiscreteUniform;

    static class Episode04
    {
        public static void DoIt()
        {
            WriteLine("Episode 04");
            WriteLine();

            WriteLine("10d6:");
            WriteLine(SDU.Distribution(1, 6).Samples().Take(10).Sum());
            WriteLine();

            WriteLine("1d10:");
            WriteLine(SDU.Distribution(1, 10).Histogram());
            WriteLine();

            WriteLine("1d6:");
            WriteLine(SDU.Distribution(1, 6).ShowWeights());
            WriteLine();
        }
    }
}