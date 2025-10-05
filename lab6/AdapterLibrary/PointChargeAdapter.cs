using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.AdapterLibrary
{
    public class PointChargeAdapter : IObject
    {
        protected PointCharge charge;

        public PointChargeAdapter(PointCharge charge)
        {
            this.charge = charge;
        }

        public void Move(double dx, double dy)
        {
            charge.x += dx;
            charge.y += dy;
        }

        public double CalculateForce(double q, double r, double a)
        {
            return charge.F((int)q, r);
        }

        public string GetData()
        {
            return $"Charge: {charge.q}, Position: ({charge.x}, {charge.y})";
        }
    }

}