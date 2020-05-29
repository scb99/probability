﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Probability
{
    public sealed class Empty<T> : 
        IDiscreteDistribution<T>, IWeightedDistribution<T>
    {
        private static readonly Empty<T> distribution = new Empty<T>();

        private Empty() { }

        public static Empty<T> Distribution => distribution;

        public T Sample() => throw new Exception("Cannot sample from empty distribution");

        public IEnumerable<T> Support() => Enumerable.Empty<T>();

        public int Weight(T t) => 0;

        double IWeightedDistribution<T>.Weight(T t) => 0;
    }
}