using TransportLib.Transports;

namespace TransportLib.Factories
{
    /// <summary>
    /// Concrete factory for creating Truck transport instances
    /// </summary>
    public class TruckFactory : TransportFactory
    {
        /// <summary>
        /// Creates a new Truck transport instance
        /// </summary>
        /// <returns>A new Truck instance</returns>
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }
}