namespace TransportLib.Transports
{
    /// <summary>
    /// Truck transport implementation with ground delivery costs
    /// </summary>
    public class Truck : ITransport
    {
        private const double CostPerMile = 1.00;

        /// <summary>
        /// Calculates delivery cost for truck transport
        /// Cost per mile for truck is $1.00
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