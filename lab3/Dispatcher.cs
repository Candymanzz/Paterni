using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace lab3
{
    public interface IRouteMonitor
    {
        void Monitor();
        void IncreaseInterval();
    }

    public interface IVehicleDispatcher
    {
        void DispatchVehicle();
    }

    public class Dispatcher : IRouteMonitor, IVehicleDispatcher
    {
        private readonly Route managedRoute;
        private readonly Vehicle backupVehicle;

        public Dispatcher(Route route, Vehicle backup)
        {
            managedRoute = route ?? throw new ArgumentNullException(nameof(route));
            backupVehicle = backup ?? throw new ArgumentNullException(nameof(backup));
        }

        public void Monitor()
        {
            Console.WriteLine($"Monitoring route: {managedRoute.RouteId}");
            if (managedRoute.CurrentVehicle?.Status == VehicleStatus.Broken)
            {
                Console.WriteLine(
                    $"Vehicle {managedRoute.CurrentVehicle.VehicleId} is broken on route {managedRoute.RouteId}"
                );
                DispatchVehicle();
            }
        }

        public void DispatchVehicle()
        {
            Console.WriteLine(
                $"Dispatching reserve vehicle {backupVehicle.VehicleId} to route: {managedRoute.RouteId}"
            );
            managedRoute.AssignReserveVehicle(backupVehicle);
            backupVehicle.Move();
        }

        public void IncreaseInterval()
        {
            Console.WriteLine($"Increasing interval for route: {managedRoute.RouteId}");
            managedRoute.IncreaseInterval(5);
        }
    }
}
