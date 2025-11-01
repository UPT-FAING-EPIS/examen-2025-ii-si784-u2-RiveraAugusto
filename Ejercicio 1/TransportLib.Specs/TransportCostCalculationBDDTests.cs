using TransportLib.Factories;
using Xunit;

namespace TransportLib.Specs
{
    /// <summary>
    /// BDD-style tests for Transport Cost Calculation
    /// Feature: Transport Cost Calculation
    /// As a logistics manager
    /// I want to calculate delivery costs for different transport types
    /// So that I can choose the most cost-effective transport option
    /// </summary>
    public class TransportCostCalculationBDDTests
    {
        /// <summary>
        /// Scenario: Calculate truck delivery cost
        /// Given I have a truck factory
        /// When I calculate the delivery cost for 100 miles
        /// Then the cost should be 100.0 dollars
        /// </summary>
        [Fact]
        public void Scenario_CalculateTruckDeliveryCost()
        {
            // Given I have a truck factory
            var truckFactory = new TruckFactory();

            // When I calculate the delivery cost for 100 miles
            var cost = truckFactory.CalculateDeliveryCost(100);

            // Then the cost should be 100.0 dollars
            Assert.Equal(100.0, cost);
        }

        /// <summary>
        /// Scenario: Calculate ship delivery cost
        /// Given I have a ship factory
        /// When I calculate the delivery cost for 200 miles
        /// Then the cost should be 100.0 dollars
        /// </summary>
        [Fact]
        public void Scenario_CalculateShipDeliveryCost()
        {
            // Given I have a ship factory
            var shipFactory = new ShipFactory();

            // When I calculate the delivery cost for 200 miles
            var cost = shipFactory.CalculateDeliveryCost(200);

            // Then the cost should be 100.0 dollars
            Assert.Equal(100.0, cost);
        }

        /// <summary>
        /// Scenario: Calculate airbus delivery cost
        /// Given I have an airbus factory
        /// When I calculate the delivery cost for 50 miles
        /// Then the cost should be 150.0 dollars
        /// </summary>
        [Fact]
        public void Scenario_CalculateAirbusDeliveryCost()
        {
            // Given I have an airbus factory
            var airbusFactory = new AirbusFactory();

            // When I calculate the delivery cost for 50 miles
            var cost = airbusFactory.CalculateDeliveryCost(50);

            // Then the cost should be 150.0 dollars
            Assert.Equal(150.0, cost);
        }

        /// <summary>
        /// Scenario Outline: Calculate delivery costs for different transport types
        /// Examples: Various transport types and distances
        /// </summary>
        [Theory]
        [InlineData("truck", 50, 50.0)]
        [InlineData("truck", 150, 150.0)]
        [InlineData("ship", 100, 50.0)]
        [InlineData("ship", 300, 150.0)]
        [InlineData("airbus", 25, 75.0)]
        [InlineData("airbus", 100, 300.0)]
        public void ScenarioOutline_CalculateDeliveryCostsForDifferentTransportTypes(
            string transportType, int distance, double expectedCost)
        {
            // Given I have a transport factory of the specified type
            TransportFactory factory = transportType.ToLower() switch
            {
                "truck" => new TruckFactory(),
                "ship" => new ShipFactory(),
                "airbus" => new AirbusFactory(),
                _ => throw new ArgumentException($"Unknown transport type: {transportType}")
            };

            // When I calculate the delivery cost for the specified distance
            var cost = factory.CalculateDeliveryCost(distance);

            // Then the cost should be the expected amount
            Assert.Equal(expectedCost, cost);
        }

        /// <summary>
        /// Scenario: Handle zero distance
        /// Given I have a truck factory
        /// When I calculate the delivery cost for 0 miles
        /// Then the cost should be 0.0 dollars
        /// </summary>
        [Fact]
        public void Scenario_HandleZeroDistance()
        {
            // Given I have a truck factory
            var truckFactory = new TruckFactory();

            // When I calculate the delivery cost for 0 miles
            var cost = truckFactory.CalculateDeliveryCost(0);

            // Then the cost should be 0.0 dollars
            Assert.Equal(0.0, cost);
        }

        /// <summary>
        /// Scenario Outline: Handle invalid distances
        /// Examples: Various transport types with negative distances
        /// </summary>
        [Theory]
        [InlineData("truck", -10)]
        [InlineData("ship", -5)]
        [InlineData("airbus", -15)]
        public void ScenarioOutline_HandleInvalidDistances(string transportType, int invalidDistance)
        {
            // Given I have a transport factory of the specified type
            TransportFactory factory = transportType.ToLower() switch
            {
                "truck" => new TruckFactory(),
                "ship" => new ShipFactory(),
                "airbus" => new AirbusFactory(),
                _ => throw new ArgumentException($"Unknown transport type: {transportType}")
            };

            // When I try to calculate the delivery cost for an invalid distance
            // Then an argument exception should be thrown
            Assert.Throws<ArgumentException>(() => factory.CalculateDeliveryCost(invalidDistance));
        }

        /// <summary>
        /// Scenario: Verify factory creates correct transport type
        /// Given I have different transport factories
        /// When I create transport instances
        /// Then each factory should create the correct transport type
        /// </summary>
        [Theory]
        [InlineData(typeof(TruckFactory), "Truck")]
        [InlineData(typeof(ShipFactory), "Ship")]
        [InlineData(typeof(AirbusFactory), "Airbus")]
        public void Scenario_VerifyFactoryCreatesCorrectTransportType(Type factoryType, string expectedTransportTypeName)
        {
            // Given I have a transport factory of the specified type
            var factory = (TransportFactory)Activator.CreateInstance(factoryType)!;

            // When I create a transport instance
            var transport = factory.CreateTransport();

            // Then the transport should be of the expected type
            Assert.Equal(expectedTransportTypeName, transport.GetType().Name);
        }

        /// <summary>
        /// Scenario: Verify consistent cost calculation between factory and transport
        /// Given I have transport factories
        /// When I calculate costs using both factory method and direct transport method
        /// Then both methods should return the same result
        /// </summary>
        [Theory]
        [InlineData(typeof(TruckFactory), 75)]
        [InlineData(typeof(ShipFactory), 120)]
        [InlineData(typeof(AirbusFactory), 40)]
        public void Scenario_VerifyConsistentCostCalculation(Type factoryType, int distance)
        {
            // Given I have a transport factory
            var factory = (TransportFactory)Activator.CreateInstance(factoryType)!;

            // When I calculate costs using both methods
            var costFromFactory = factory.CalculateDeliveryCost(distance);
            var transport = factory.CreateTransport();
            var costFromTransport = transport.GetDeliveryCost(distance);

            // Then both methods should return the same result
            Assert.Equal(costFromFactory, costFromTransport);
        }
    }
}