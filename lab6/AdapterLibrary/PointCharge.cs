using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.AdapterLibrary
{
    public class PointCharge
    {
        public double q { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public double F(int m, double r)
        {
            return (q * m) / (r * r); // простая формула
        }
    }

}