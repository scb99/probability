using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    using SCU = StandardContinuousUniform;

    /// <summary>
    /// Implements a discrete uniform distribution (i.e., a symmetric probability 
    /// distribution wherein a finite number of values are equally likely to be 
    /// observed; every one of n values has equal probability 1/n.
    /// </summary>
    public sealed class StandardDiscreteUniform :
        IDiscreteDistribution<int>, IWeightedDistribution<int>
    {
        /// <summary>
        /// Returns a standard discrete uniform probability distribution over the integers
        /// </summary>
        /// <param name="min">Minimum value of discrete distribution</param>
        /// <param name="max">Maximum value of discrete distribution</param>
        /// <returns>A standard discrete uniform probability distribution 
        /// with integer outcomes between min and max inclusive</returns>
        public static IDiscreteDistribution<int> Distribution(int min, int max)
        {
            if (min > max)
            {
                return Empty<int>.Distribution;
            }

            if (min == max)
            {
                return Singleton<int>.Distribution(min);
            }

            return new StandardDiscreteUniform(min, max);
        }

        public int Min { get; }

        public int Max { get; }

        private StandardDiscreteUniform(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Returns set of possible outcomes of standard discrete uniform distribtuion
        /// </summary>
        /// <returns>Returns a sequence of values of possible outcomes of a standard discrete uniform distribution.</returns>
        public IEnumerable<int> Support() =>
            Enumerable.Range(Min, 1 + Max - Min);

        /// <summary>
        /// Generates a random sample from a standard discrete uniform distribution
        /// </summary>
        /// <returns>An integer from the support of the standard discrete uniform distribution;
        /// each value in the support will be chosen with equal probability.</returns>
        public int Sample() =>
            (int)((SCU.Distribution.Sample() * (1.0 + Max - Min)) + Min);

        /// <summary>
        /// Determines weight of parameter
        /// </summary>
        /// <param name="t">The parameter</param>
        /// <returns>Returns 1 if parameter is in the support, else 0</returns>
        public int Weight(int t) =>
            (Min <= t && t <= Max) ? 1 : 0;

        /// <summary>
        /// Determines weight of parameter
        /// </summary>
        /// <param name="t">The parameter</param>
        /// <returns>Returns 1.0 if parameter is in the support, else 0</returns>
        double IWeightedDistribution<int>.Weight(int t) => this.Weight(t);

        public override string ToString() => 
            $"StandardDiscreteUniform[{Min}, {Max}]";
    }
}