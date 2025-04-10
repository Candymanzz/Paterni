using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Route
    {
        private readonly int routeId;
        private readonly string name;
        private int interval;
        private Vehicle? currentVehicle;
        private Vehicle? reserveVehicle;

        public int RouteId => routeId;
        public string Name => name;
        public int Interval => interval;
        public Vehicle? CurrentVehicle => currentVehicle;
        public Vehicle? ReserveVehicle => reserveVehicle;

        public Route(int routeId, string name, int interval)
        {
            this.routeId = routeId;
            this.name = name;
            this.interval = interval;
        }

        public void AssignVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            currentVehicle = vehicle;
        }

        public void AssignReserveVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle));
            }
            reserveVehicle = vehicle;
        }

        public void IncreaseInterval(int additionalInterval)
        {
            if (additionalInterval <= 0)
            {
                throw new ArgumentException(
                    "Interval must be positive",
                    nameof(additionalInterval)
                );
            }
            interval += additionalInterval;
        }

        public void DecreaseInterval(int reduction)
        {
            if (reduction <= 0)
            {
                throw new ArgumentException("Reduction must be positive", nameof(reduction));
            }
            if (interval - reduction < 1)
            {
                throw new InvalidOperationException("Interval cannot be less than 1");
            }
            interval -= reduction;
        }
    }
}
