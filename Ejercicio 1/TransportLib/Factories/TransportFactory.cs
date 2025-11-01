namespace TransportLib.Factories
{
    /// <summary>
    /// Abstract factory class for creating transport instances
    /// Implements the Factory Method pattern
    /// </summary>
    public abstract class TransportFactory
    {
        /// <summary>
        /// Factory method to create transport instances
        /// </summary>
        /// <returns>An instance of ITransport</returns>
        public abstract ITransport CreateTransport();

        /// <summary>
        /// Template method that uses the factory method to create transport and calculate cost
        /// </summary>
        /// <param name="distance">Distance for delivery</param>
        /// <returns>Delivery cost for the specific transport type</returns>
        public double CalculateDeliveryCost(int distance)
        {
            var transport = CreateTransport();
            return transport.GetDeliveryCost(distance);
        }
    }
}