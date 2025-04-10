using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Public Transport System\n");

            // Create routes
            var route1 = new Route(1, "Main Street Route", 10);
            var route2 = new Route(2, "Downtown Route", 15);

            // Create vehicles
            var bus1 = new Bus(50, route1, "Bus", 1, "Diesel");
            var tram1 = new Tram(100, route1, "Tram", 2, 1435.0f);
            var trolleybus1 = new Trolleybus(40, route2, "Trolleybus", 3, 600);

            // Create backup vehicles
            var backupBus = new Bus(50, null, "Bus", 4, "Diesel");
            var backupTram = new Tram(100, null, "Tram", 5, 1435.0f);

            Console.WriteLine("Initial State:");
            Console.WriteLine($"Route 1: {route1.Name}, Interval: {route1.Interval} minutes");
            Console.WriteLine($"Route 2: {route2.Name}, Interval: {route2.Interval} minutes\n");

            // Assign vehicles to routes
            route1.AssignVehicle(bus1);
            route2.AssignVehicle(trolleybus1);

            Console.WriteLine("After assigning vehicles:");
            Console.WriteLine(
                $"Route 1 vehicle: {route1.CurrentVehicle.Type} #{route1.CurrentVehicle.VehicleId}"
            );
            Console.WriteLine(
                $"Route 2 vehicle: {route2.CurrentVehicle.Type} #{route2.CurrentVehicle.VehicleId}\n"
            );

            // Test vehicle operations
            Console.WriteLine("Testing vehicle operations:");
            bus1.Move();
            Console.WriteLine($"Bus #{bus1.VehicleId} status: {bus1.Status}");

            bus1.BreakDown();
            Console.WriteLine($"Bus #{bus1.VehicleId} status: {bus1.Status}");

            tram1.ChangeTrack();
            Console.WriteLine($"Tram #{tram1.VehicleId} status: {tram1.Status}");

            trolleybus1.ConnectToWires();
            Console.WriteLine(
                $"Trolleybus #{trolleybus1.VehicleId} status: {trolleybus1.Status}\n"
            );

            // Test maintenance
            Console.WriteLine("Testing maintenance:");
            bus1.PerformMaintenance();
            tram1.PerformMaintenance();
            trolleybus1.PerformMaintenance();
            Console.WriteLine();

            // Test dispatcher
            Console.WriteLine("Testing dispatcher:");
            var dispatcher1 = new Dispatcher(route1, backupBus);
            var dispatcher2 = new Dispatcher(route2, backupTram);

            dispatcher1.Monitor();
            dispatcher1.DispatchVehicle();
            Console.WriteLine(
                $"Route 1 reserve vehicle: {route1.ReserveVehicle.Type} #{route1.ReserveVehicle.VehicleId}"
            );

            dispatcher1.IncreaseInterval();
            Console.WriteLine($"Route 1 new interval: {route1.Interval} minutes\n");

            // Test route operations
            Console.WriteLine("Testing route operations:");
            route1.IncreaseInterval(5);
            Console.WriteLine($"Route 1 interval after increase: {route1.Interval} minutes");

            route1.DecreaseInterval(3);
            Console.WriteLine($"Route 1 interval after decrease: {route1.Interval} minutes");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
