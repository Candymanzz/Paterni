using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Trolleybus : Vehicle
    {
        private readonly int voltage;
        public int Voltage => voltage;

        public Trolleybus(int capacity, Route currentRoute, string type, int vehicleId, int voltage)
            : base(capacity, currentRoute, type, vehicleId)
        {
            this.voltage = voltage;
        }

        public void ConnectToWires()
        {
            status = VehicleStatus.Repairing;
        }

        public override void PerformMaintenance()
        {
            Console.WriteLine($"Performing maintenance on trolleybus {VehicleId}");
            Repair();
        }
    }
}
