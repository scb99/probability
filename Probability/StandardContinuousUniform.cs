namespace Probability
{
    public sealed class StandardContinuousUniform :
        IWeightedDistribution<double>
    {
        private StandardContinuousUniform() { }

        public static StandardContinuousUniform Distribution { get; set; } = new StandardContinuousUniform();

        public double Sample() => Pseudorandom.NextDouble();

        public double Weight(double t) => 0.0 <= t & t < 1.0 ? 1.0 : 0.0;
    }
}