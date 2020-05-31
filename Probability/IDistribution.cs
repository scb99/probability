namespace Probability
{
    public interface IDistribution<T>
    {
        /// <summary>
        /// A distibution of type T must be able to return a random value
        /// of type T from the support of the distribution
        /// </summary>
        /// <returns>A random value of type T from the support of the distribution</returns>
        T Sample();
    }
}