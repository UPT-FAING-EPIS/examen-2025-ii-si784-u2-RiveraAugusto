using TransportLib.Factories;
using TransportLib.Transports;
using Xunit;

namespace TransportLib.Tests
{
    /// <summary>
    /// Unit tests for factory classes
    /// </summary>
    public class FactoryTests
    {
        [Fact]
        public void TruckFactory_CreateTransport_ReturnsTruckInstance()
        {
            // Arrange
            var factory = new TruckFactory();

            // Act
            var transport = factory.CreateTransport();

            // Assert
            Assert.NotNull(transport);
            Assert.IsType<Truck>(transport);
        }

        [Fact]
        public void ShipFactory_CreateTransport_ReturnsShipInstance()
        {
            // Arrange
            var factory = new ShipFactory();

            // Act
            var transport = factory.CreateTransport();

            // Assert
            Assert.NotNull(transport);
            Assert.IsType<Ship>(transport);
        }

        [Fact]
        public void AirbusFactory_CreateTransport_ReturnsAirbusInstance()
        {
            // Arrange
            var factory = new AirbusFactory();

            // Act
            var transport = factory.CreateTransport();

            // Assert
            Assert.NotNull(transport);
            Assert.IsType<Airbus>(transport);
        }

        [Fact]
        public void TruckFactory_CalculateDeliveryCost_ValidDistance_ReturnsCorrectCost()
        {
            // Arrange
            var factory = new TruckFactory();
            int distance = 100;
            double expectedCost = 100.0; // $1.00 per mile

            // Act
            var actualCost = factory.CalculateDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void ShipFactory_CalculateDeliveryCost_ValidDistance_ReturnsCorrectCost()
        {
            // Arrange
            var factory = new ShipFactory();
            int distance = 200;
            double expectedCost = 100.0; // $0.50 per mile

            // Act
            var actualCost = factory.CalculateDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void AirbusFactory_CalculateDeliveryCost_ValidDistance_ReturnsCorrectCost()
        {
            // Arrange
            var factory = new AirbusFactory();
            int distance = 50;
            double expectedCost = 150.0; // $3.00 per mile

            // Act
            var actualCost = factory.CalculateDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void TruckFactory_CalculateDeliveryCost_ZeroDistance_ReturnsZero()
        {
            // Arrange
            var factory = new TruckFactory();
            int distance = 0;

            // Act
            var actualCost = factory.CalculateDeliveryCost(distance);

            // Assert
            Assert.Equal(0.0, actualCost);
        }

        [Fact]
        public void ShipFactory_CalculateDeliveryCost_ZeroDistance_ReturnsZero()
        {
            // Arrange
            var factory = new ShipFactory();
            int distance = 0;

            // Act
            var actualCost = factory.CalculateDeliveryCost(distance);

            // Assert
            Assert.Equal(0.0, actualCost);
        }

        [Fact]
        public void AirbusFactory_CalculateDeliveryCost_ZeroDistance_ReturnsZero()
        {
            // Arrange
            var factory = new AirbusFactory();
            int distance = 0;

            // Act
            var actualCost = factory.CalculateDeliveryCost(distance);

            // Assert
            Assert.Equal(0.0, actualCost);
        }

        [Fact]
        public void TruckFactory_CalculateDeliveryCost_NegativeDistance_ThrowsArgumentException()
        {
            // Arrange
            var factory = new TruckFactory();
            int distance = -10;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CalculateDeliveryCost(distance));
        }

        [Fact]
        public void ShipFactory_CalculateDeliveryCost_NegativeDistance_ThrowsArgumentException()
        {
            // Arrange
            var factory = new ShipFactory();
            int distance = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CalculateDeliveryCost(distance));
        }

        [Fact]
        public void AirbusFactory_CalculateDeliveryCost_NegativeDistance_ThrowsArgumentException()
        {
            // Arrange
            var factory = new AirbusFactory();
            int distance = -15;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CalculateDeliveryCost(distance));
        }

        [Theory]
        [InlineData(typeof(TruckFactory), typeof(Truck))]
        [InlineData(typeof(ShipFactory), typeof(Ship))]
        [InlineData(typeof(AirbusFactory), typeof(Airbus))]
        public void Factories_CreateTransport_ReturnsCorrectTransportType(Type factoryType, Type expectedTransportType)
        {
            // Arrange
            var factory = (TransportFactory)Activator.CreateInstance(factoryType)!;

            // Act
            var transport = factory.CreateTransport();

            // Assert
            Assert.NotNull(transport);
            Assert.IsType(expectedTransportType, transport);
        }
    }
}