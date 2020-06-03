using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    /// <summary>
    /// The probability distribution where 100% of the time it returns 
    /// the same value (aka the “Dirac delta” or the “Kronecker delta”).
    /// </summary>
    /// <typeparam name="T">The type of value(s) in the distribution</typeparam>
    public sealed class Singleton<T> : 
        IDiscreteDistribution<T>, IWeightedDistribution<T>
    {
        private readonly T t;

        /// <summary>
        /// Implements a Dirac delta probability distribution over the value of type T
        /// </summary>
        /// <param name="t">The value of the distribution</param>
        /// <returns>Returns a Dirac delta probability distribution using a value of type T</returns>
        public static Singleton<T> Distribution(T t) => new Singleton<T>(t);

        private Singleton(T t) => this.t = t;

        /// <summary>
        /// Generates a random sample from the Dirac delta distribution
        /// </summary>
        /// <returns>There is only one value to return</returns>
        public T Sample() => t;

        /// <summary>
        /// Returns set of possible outcomes of Dirac delta distribtuion.
        /// </summary>
        /// <returns>The returned set/sequence contains one element.</returns>
        public IEnumerable<T> Support() => Enumerable.Repeat(this.t, 1);

        /// <summary>
        /// Determines the weight of the parameter
        /// </summary>
        /// <param name="t">The parameter</param>
        /// <returns>Returns 1 if parameter is in the support, else 0</returns>
        public int Weight(T t) => EqualityComparer<T>.Default.Equals(this.t, t) ? 1 : 0;

        public override string ToString() => $"Singleton[{t}]";

        /// <summary>
        /// Determines the weight of the parameter
        /// </summary>
        /// <param name="t">The parameter</param>
        /// <returns>Returns 1.0 if parameter is in the support, else 0.0</returns>
        double IWeightedDistribution<T>.Weight(T t) => this.Weight(t);
    }
}