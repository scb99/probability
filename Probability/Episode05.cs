using static System.Console;

namespace Probability
{
    static class Episode05
    {
        public static void DoIt()
        {
            WriteLine("Episode 05");
            WriteLine();

            WriteLine("Bernoulli 75% chance of 1");
            WriteLine(Bernoulli.Distribution(1, 3).Histogram());
            WriteLine();
        }
    }
}