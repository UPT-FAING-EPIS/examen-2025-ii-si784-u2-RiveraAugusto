using TransportLib.Transports;

namespace TransportLib.Factories
{
    /// <summary>
    /// Concrete factory for creating Ship transport instances
    /// </summary>
    public class ShipFactory : TransportFactory
    {
        /// <summary>
        /// Creates a new Ship transport instance
        /// </summary>
        /// <returns>A new Ship instance</returns>
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }
}