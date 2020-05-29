﻿using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    using SCU = StandardContinuousUniform;

    public sealed class StandardDiscreteUniform :
      IDiscreteDistribution<int>,
      IWeightedDistribution<int>
    {
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

        public IEnumerable<int> Support() =>
            Enumerable.Range(Min, 1 + Max - Min);

        public int Sample() =>
            (int)((SCU.Distribution.Sample() * (1.0 + Max - Min)) + Min);

        public int Weight(int t) =>
            (Min <= t && t <= Max) ? 1 : 0;

        double IWeightedDistribution<int>.Weight(int t) => this.Weight(t);

        public override string ToString() =>
            $"StandardDiscreteUniform[{Min}, {Max}]";
    }
}