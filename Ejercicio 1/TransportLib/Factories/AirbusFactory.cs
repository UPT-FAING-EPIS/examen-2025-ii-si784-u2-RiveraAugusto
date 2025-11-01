using TransportLib.Transports;

namespace TransportLib.Factories
{
    /// <summary>
    /// Concrete factory for creating Airbus transport instances
    /// </summary>
    public class AirbusFactory : TransportFactory
    {
        /// <summary>
        /// Creates a new Airbus transport instance
        /// </summary>
        /// <returns>A new Airbus instance</returns>
        public override ITransport CreateTransport()
        {
            return new Airbus();
        }
    }
}