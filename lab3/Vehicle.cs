using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3
{
    public enum VehicleStatus
    {
        Moving,
        Broken,
        Repairing,
        Refueling,
    }

    public abstract class Vehicle
    {
        protected int capacity;
        protected Route currentRoute;
        protected VehicleStatus status;
        protected string type = string.Empty;
        private int vehicleId;

        public int Capacity => capacity;
        public Route CurrentRoute => currentRoute;
        public VehicleStatus Status => status;
        public string Type => type;
        public int VehicleId => vehicleId;

        protected Vehicle(int capacity, Route currentRoute, string type, int vehicleId)
        {
            this.capacity = capacity;
            this.currentRoute = currentRoute;
            this.type = type;
            this.vehicleId = vehicleId;
            this.status = VehicleStatus.Moving;
        }

        public virtual void Move()
        {
            status = VehicleStatus.Moving;
        }

        public virtual void BreakDown()
        {
            status = VehicleStatus.Broken;
        }

        public virtual void Repair()
        {
            status = VehicleStatus.Repairing;
        }

        public abstract void PerformMaintenance();
    }
}
