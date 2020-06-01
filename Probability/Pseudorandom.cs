using System;
using System.Threading;

namespace Probability
{
    /// <summary>
    /// A threadsafe, all-static, crypto-randomized wrapper around Random.
    /// Still not great, but a slight improvement.
    /// </summary>
    public static class Pseudorandom
    {
        private static readonly ThreadLocal<Random> prng =
            new ThreadLocal<Random>(() => new Random(BetterRandom.NextInt()));

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0
        /// A 32-bit signed integer that is greater than or equal to 0</returns>
        public static int NextInt() => prng.Value.Next();

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0
        /// and less than 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number that is greater than
        /// or equal to 0.0 and less than 1.0.</returns>
        public static double NextDouble() => prng.Value.NextDouble();
    }
}