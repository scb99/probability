namespace Probability
{
    using static System.Math;
    using SCU = StandardContinuousUniform;
    public sealed class Normal : IWeightedDistribution<double>
    {
        public double Mean { get; }
        public double Sigma { get; }
        public double μ => Mean;
        public double σ => Sigma;

        /// <summary>
        /// Represents standard normal distibution (with μ = 0.0 and σ  = 1.0)
        /// </summary>
        public readonly static Normal Standard = Distribution(0, 1);
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
        /// <returns></returns>
        public double Sample() => μ + σ * StandardSample();

        /// <summary>
        /// Implements standard definition of normal distribution with mean μ and standard deviation σ
        /// </summary>
        /// <param name="x"></param>
        /// <returns>Value of normal distribution with mean μ and standard deviation σ evaluated a x</returns>
        public double Weight(double x) =>
            Exp(-(x - μ) * (x - μ) / (2 * σ * σ)) * piroot / σ;

        // Box-Muller method to genrate a normally distributed random sample
        private double StandardSample() =>
            Sqrt(-2.0 * Log(SCU.Distribution.Sample())) *
                 Cos(2.0 * PI * SCU.Distribution.Sample());

        private static readonly double piroot = 1.0 / Sqrt(2 * PI);
    }
}