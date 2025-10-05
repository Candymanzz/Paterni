using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.AdapterLibrary
{
    public interface IObject
    {
        void Move(double dx, double dy);
        double CalculateForce(double q, double r, double a);
        string GetData();
    }

}