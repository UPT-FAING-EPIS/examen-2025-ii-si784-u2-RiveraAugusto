namespace TransportLib
{
    /// <summary>
    /// Interface that defines the contract for transport services
    /// </summary>
    public interface ITransport
    {
        /// <summary>
        /// Calculates the delivery cost based on distance
        /// </summary>
        /// <param name="distance">Distance in miles</param>
        /// <returns>Cost of delivery</returns>
        double GetDeliveryCost(int distance);
    }
}