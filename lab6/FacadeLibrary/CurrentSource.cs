using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.FacadeLibrary
{
    public class CurrentSource
    {
        protected double voltage;
        public CurrentSource(double voltage) => this.voltage = voltage;
        public double GetVoltage() => voltage;
    }

    public class Resistor
    {
        protected double resistance;
        public Resistor(double resistance) => this.resistance = resistance;
        public double GetResistance() => resistance;
    }

    public class Ammeter
    {
        public double MeasureCurrent(double voltage, double resistance) =>
            voltage / resistance;
    }

    public class Voltmeter
    {
        public double MeasureVoltage(CurrentSource source) => source.GetVoltage();
    }

}