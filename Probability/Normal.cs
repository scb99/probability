namespace Probability
{
    using static System.Math;
    using SCU = StandardContinuousUniform;
    public sealed class Normal : IWeightedDistribution<double>
    {
        public double Mean { get; }
        public double Sigma { get; }
        private double μ => Mean;
        private double σ => Sigma;

        /// <summary>
        /// Represents standard normal distibution (i.e., a normal distribution 
        /// with μ = 0.0 and σ  = 1.0)
        /// </summary>
        public readonly static Normal Standard = Distribution(0, 1);

        /// <summary>
        /// Represents a normal distribution with mean μ and standard deviation σ
        /// </summary>
        /// <param name="mean">The mean of the normal distribution</param>
        /// <param name="sigma">The standard deviation of the normal distribution</param>
        /// <returns></returns>
        public static Normal Distribution(double mean, double sigma) =>
            new Normal(mean, sigma);
        private Normal(double mean, double sigma)
        {
            this.Mean = mean;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Generates a random sample that is normally distributed with mean μ and
        /// standard deviation σ
        /// </summary>
        /// <returns>A random sample that is normally distributed with mean μ and
        /// standard deviation σ</returns>
        public double Sample() => μ + σ * StandardSample();

        /// <summary>
        /// Implements standard definition of normal distribution with mean μ and standard deviation σ
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Value of normal distribution with mean μ and standard deviation σ evaluated a x</returns>
        public double Weight(double x) =>
            Exp(-(x - μ) * (x - μ) / (2 * σ * σ)) * piroot / σ;

        // Box-Muller method to generate a normally distributed random sample
        private double StandardSample() =>
            Sqrt(-2.0 * Log(SCU.Distribution.Sample())) *
                 Cos(2.0 * PI * SCU.Distribution.Sample());

        private static readonly double piroot = 1.0 / Sqrt(2 * PI);
    }
}