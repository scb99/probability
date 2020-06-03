using System;
using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    using SCU = StandardContinuousUniform;

    /// <summary>
    ///  Bernoulli distribution is the discrete probability distribution of a 
    ///  random variable which takes the value 1 with probability p and the 
    ///  value 0 with probability q=1-p. Less formally, it can be thought of 
    ///  as a model for the set of possible outcomes of any single experiment 
    ///  that asks a yes–no question. Such questions lead to outcomes that 
    ///  are boolean-valued: a single bit whose value is success/yes/true/one 
    ///  with probability p and failure/no/false/zero with probability q.
    ///  It can be used to represent a (possibly biased) coin toss where 1 
    ///  and 0 would represent "heads" and "tails" (or vice versa), respectively, 
    ///  and p would be the probability of the coin landing on heads or tails, 
    ///  respectively. In particular, unfair coins would have p neq 1/2.
    ///  (Wikepedia)
    /// </summary>
    public sealed class Bernoulli : 
        IDiscreteDistribution<int>, IWeightedDistribution<int>
    {
        /// <summary>
        /// Returns a Bernoulli distribution
        /// </summary>
        /// <param name="zero"></param>
        /// <param name="one"></param>
        /// <returns></returns>
        public static IDiscreteDistribution<int> Distribution(int zero, int one)
        {
            if (zero < 0 || one < 0)
            {
                throw new ArgumentException();
            }

            if (zero == 0 && one == 0)
            {
                return Empty<int>.Distribution;
            }

            if (zero == 0)
            {
                return Singleton<int>.Distribution(1);
            }

            if (one == 0)
            {
                return Singleton<int>.Distribution(0);
            }

            int gcd = Extensions.GCD(zero, one);

            return new Bernoulli(zero / gcd, one / gcd);
        }

        public int Zero { get; }

        public int One { get; }

        private Bernoulli(int zero, int one)
        {
            this.Zero = zero;
            this.One = one;
        }

        public int Sample() => (SCU.Distribution.Sample() <= ((double)Zero) / (Zero + One)) ? 0 : 1;

        public IEnumerable<int> Support() => Enumerable.Range(0, 2);

        public int Weight(int t) => t == 0 ? Zero : t == 1 ? One : 0;

        double IWeightedDistribution<int>.Weight(int t) => this.Weight(t);

        public override string ToString() => $"Bernoulli[{this.Zero}, {this.One}]";
    }
}