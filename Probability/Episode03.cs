using System.Linq;
using static System.Console;

namespace Probability
{
    using SCU = StandardContinuousUniform;

    static class Episode03
    {
        public static void DoIt()
        {
            WriteLine("Episode 03\n\nThe sum of 12 random doubles:");
            WriteLine(SCU.Distribution.Samples().Take(12).Sum());
            WriteLine();

            WriteLine("A histogram of the SCU:");
            WriteLine(SCU.Distribution.Histogram(0, 1));
            WriteLine();

            WriteLine("A histogram of a Gaussian:");
            WriteLine(Normal.Distribution(1.0, 1.5).Histogram(-4, 6));
        }
    }
}