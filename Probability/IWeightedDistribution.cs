namespace Probability
{
    public interface IWeightedDistribution<T> : IDistribution<T>
    {
        /// <summary>
        /// A weighted distribution (of type T) is a (continuous/discrete) distribution 
        /// (of type T) that must be able to return the weight of a random value 
        /// from the support of the distribution.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>If the distribution is continuous, the weight will be 1.0 if
        /// t belongs to the support of the (continuous) distribution; 
        /// otherwise the weight function should return 0. 
        /// If the distribution is discrete, the weight will be the frequency of
        /// t if t belongs to the support of the (discrete) distribution;
        /// otherwise the weight function should return 0.</returns>
        double Weight(T t);
    }
}