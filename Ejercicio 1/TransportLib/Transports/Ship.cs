namespace TransportLib.Transports
{
    /// <summary>
    /// Ship transport implementation with sea delivery costs
    /// </summary>
    public class Ship : ITransport
    {
        private const double CostPerMile = 0.50;

        /// <summary>
        /// Calculates delivery cost for ship transport
        /// Cost per mile for ship is $0.50
        /// </summary>
        /// <param name="distance">Distance in miles</param>
        /// <returns>Total delivery cost</returns>
        public double GetDeliveryCost(int distance)
        {
            if (distance < 0)
                throw new ArgumentException("Distance cannot be negative", nameof(distance));
            
            return CostPerMile * distance;
        }
    }
}