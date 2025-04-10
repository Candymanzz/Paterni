using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public class Tram : Vehicle
    {
        private readonly float trackGauge;

        public float TrackGauge => trackGauge;

        public Tram(int capacity, Route currentRoute, string type, int vehicleId, float trackGauge)
            : base(capacity, currentRoute, type, vehicleId)
        {
            this.trackGauge = trackGauge;
        }

        public void ChangeTrack()
        {
            status = VehicleStatus.Repairing;
        }

        public override void PerformMaintenance()
        {
            Console.WriteLine($"Performing maintenance on tram {VehicleId}");
            Repair();
        }
    }
}
