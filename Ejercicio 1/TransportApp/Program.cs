using TransportLib.Factories;

namespace TransportApp
{
    /// <summary>
    /// Console application demonstrating the Factory Method pattern
    /// for transport delivery cost calculations
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Transport Delivery Cost Calculator ===");
            Console.WriteLine("Demonstrating Factory Method Pattern\n");

            // Test distance
            int testDistance = 100;
            
            Console.WriteLine($"Calculating delivery costs for {testDistance} miles:\n");

            // Create different transport factories
            var factories = new List<(string Name, TransportFactory Factory)>
            {
                ("Truck", new TruckFactory()),
                ("Ship", new ShipFactory()),
                ("Airbus", new AirbusFactory())
            };

            // Calculate and display costs for each transport type
            foreach (var (name, factory) in factories)
            {
                try
                {
                    var transport = factory.CreateTransport();
                    var cost = transport.GetDeliveryCost(testDistance);
                    
                    Console.WriteLine($"{name} Transport:");
                    Console.WriteLine($"  - Cost per mile: ${cost / testDistance:F2}");
                    Console.WriteLine($"  - Total cost for {testDistance} miles: ${cost:F2}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error calculating cost for {name}: {ex.Message}");
                }
            }

            // Interactive mode
            Console.WriteLine("=== Interactive Mode ===");
            while (true)
            {
                Console.WriteLine("\nSelect transport type:");
                Console.WriteLine("1. Truck ($1.00 per mile)");
                Console.WriteLine("2. Ship ($0.50 per mile)");
                Console.WriteLine("3. Airbus ($3.00 per mile)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");

                var choice = Console.ReadLine();
                
                if (choice == "4")
                {
                    Console.WriteLine("Thank you for using the Transport Calculator!");
                    break;
                }

                TransportFactory? selectedFactory = choice switch
                {
                    "1" => new TruckFactory(),
                    "2" => new ShipFactory(),
                    "3" => new AirbusFactory(),
                    _ => null
                };

                if (selectedFactory == null)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                Console.Write("Enter distance in miles: ");
                if (int.TryParse(Console.ReadLine(), out int distance) && distance >= 0)
                {
                    try
                    {
                        var cost = selectedFactory.CalculateDeliveryCost(distance);
                        var transportName = selectedFactory.GetType().Name.Replace("Factory", "");
                        
                        Console.WriteLine($"\n{transportName} delivery cost for {distance} miles: ${cost:F2}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid distance. Please enter a non-negative number.");
                }
            }
        }
    }
}
