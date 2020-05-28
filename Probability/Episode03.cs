﻿using System;
using System.Linq;

namespace Probability
{
    using SCU = StandardContinuousUniform;

    static class Episode03
    {
        public static void DoIt()
        {
            Console.WriteLine("\nEpisode 03\n\nThe sum of 12 random doubles:");
            Console.WriteLine(SCU.Distribution.Samples().Take(12).Sum());
            Console.WriteLine();

            Console.WriteLine("A histogram of the SCU:");
            Console.WriteLine(SCU.Distribution.Histogram(0, 1));
            Console.WriteLine();

            Console.WriteLine("A histogram of a Gaussian:");
            Console.WriteLine(Normal.Distribution(1.0, 1.5).Histogram(-4, 6));
        }
    }
}