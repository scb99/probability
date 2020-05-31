namespace Probability
{
    /// <summary>
    /// Represents a continuous uniform distribution on [0.0, 1.0)
    /// </summary>
    public sealed class StandardContinuousUniform :
        IWeightedDistribution<double>
    {
        private StandardContinuousUniform()
        {
        }

        /// <summary>
        /// Represents a continuous uniform distribution of reals over the interval [0.0, 1.0).
        /// </summary>
        public static StandardContinuousUniform Distribution { get; set; } = new StandardContinuousUniform();

        /// <summary>
        /// Generates a sample from the standard continuous uniform distribution
        /// </summary>
        /// <returns>A double over interval [0.0, 1.0)</returns>
        public double Sample() => Pseudorandom.NextDouble();

        /// <summary>
        /// Determines weight of parameter
        /// </summary>
        /// <param name="t"></param>
        /// <returns>1.0 if parameter is in interval [0.0, 1.0), else 0.0</returns>
        public double Weight(double t) => 0.0 <= t & t < 1.0 ? 1.0 : 0.0;
    }
}