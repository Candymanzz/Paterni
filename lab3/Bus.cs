using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Bus : Vehicle
    {
        private readonly string fuelType;

        public Bus(int capacity, Route currentRoute, string type, int vehicleId, string fuelType)
            : base(capacity, currentRoute, type, vehicleId)
        {
            this.fuelType = fuelType;
        }

        public void Refuel()
        {
            status = VehicleStatus.Refueling;
        }

        public override void PerformMaintenance()
        {
            Console.WriteLine($"Performing maintenance on bus {VehicleId}");
            Repair();
        }
    }
}
