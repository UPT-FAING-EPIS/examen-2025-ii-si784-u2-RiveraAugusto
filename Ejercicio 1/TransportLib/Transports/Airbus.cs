namespace TransportLib.Transports
{
    /// <summary>
    /// Airbus transport implementation with air delivery costs
    /// </summary>
    public class Airbus : ITransport
    {
        private const double CostPerMile = 3.00;

        /// <summary>
        /// Calculates delivery cost for air transport
        /// Cost per mile for airbus is $3.00
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