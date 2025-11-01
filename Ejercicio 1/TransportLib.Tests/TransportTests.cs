using TransportLib.Transports;
using Xunit;

namespace TransportLib.Tests
{
    /// <summary>
    /// Unit tests for transport classes
    /// </summary>
    public class TransportTests
    {
        [Fact]
        public void Truck_GetDeliveryCost_ValidDistance_ReturnsCorrectCost()
        {
            // Arrange
            var truck = new Truck();
            int distance = 100;
            double expectedCost = 100.0; // $1.00 per mile

            // Act
            var actualCost = truck.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void Truck_GetDeliveryCost_ZeroDistance_ReturnsZero()
        {
            // Arrange
            var truck = new Truck();
            int distance = 0;

            // Act
            var actualCost = truck.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(0.0, actualCost);
        }

        [Fact]
        public void Truck_GetDeliveryCost_NegativeDistance_ThrowsArgumentException()
        {
            // Arrange
            var truck = new Truck();
            int distance = -10;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => truck.GetDeliveryCost(distance));
        }

        [Fact]
        public void Ship_GetDeliveryCost_ValidDistance_ReturnsCorrectCost()
        {
            // Arrange
            var ship = new Ship();
            int distance = 200;
            double expectedCost = 100.0; // $0.50 per mile

            // Act
            var actualCost = ship.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void Ship_GetDeliveryCost_ZeroDistance_ReturnsZero()
        {
            // Arrange
            var ship = new Ship();
            int distance = 0;

            // Act
            var actualCost = ship.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(0.0, actualCost);
        }

        [Fact]
        public void Ship_GetDeliveryCost_NegativeDistance_ThrowsArgumentException()
        {
            // Arrange
            var ship = new Ship();
            int distance = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => ship.GetDeliveryCost(distance));
        }

        [Fact]
        public void Airbus_GetDeliveryCost_ValidDistance_ReturnsCorrectCost()
        {
            // Arrange
            var airbus = new Airbus();
            int distance = 50;
            double expectedCost = 150.0; // $3.00 per mile

            // Act
            var actualCost = airbus.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Fact]
        public void Airbus_GetDeliveryCost_ZeroDistance_ReturnsZero()
        {
            // Arrange
            var airbus = new Airbus();
            int distance = 0;

            // Act
            var actualCost = airbus.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(0.0, actualCost);
        }

        [Fact]
        public void Airbus_GetDeliveryCost_NegativeDistance_ThrowsArgumentException()
        {
            // Arrange
            var airbus = new Airbus();
            int distance = -15;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => airbus.GetDeliveryCost(distance));
        }

        [Theory]
        [InlineData(1, 1.0)]
        [InlineData(10, 10.0)]
        [InlineData(100, 100.0)]
        [InlineData(1000, 1000.0)]
        public void Truck_GetDeliveryCost_VariousDistances_ReturnsCorrectCosts(int distance, double expectedCost)
        {
            // Arrange
            var truck = new Truck();

            // Act
            var actualCost = truck.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Theory]
        [InlineData(1, 0.5)]
        [InlineData(10, 5.0)]
        [InlineData(100, 50.0)]
        [InlineData(1000, 500.0)]
        public void Ship_GetDeliveryCost_VariousDistances_ReturnsCorrectCosts(int distance, double expectedCost)
        {
            // Arrange
            var ship = new Ship();

            // Act
            var actualCost = ship.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }

        [Theory]
        [InlineData(1, 3.0)]
        [InlineData(10, 30.0)]
        [InlineData(100, 300.0)]
        [InlineData(1000, 3000.0)]
        public void Airbus_GetDeliveryCost_VariousDistances_ReturnsCorrectCosts(int distance, double expectedCost)
        {
            // Arrange
            var airbus = new Airbus();

            // Act
            var actualCost = airbus.GetDeliveryCost(distance);

            // Assert
            Assert.Equal(expectedCost, actualCost);
        }
    }
}