using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.FacadeLibrary
{
    public class ElectricalCircuitFacade
    {
        private CurrentSource source;
        private Resistor resistor;
        private Ammeter ammeter;
        private Voltmeter voltmeter;

        public ElectricalCircuitFacade(double voltage, double resistance)
        {
            source = new CurrentSource(voltage);
            resistor = new Resistor(resistance);
            ammeter = new Ammeter();
            voltmeter = new Voltmeter();
        }

        public double GetCurrent() =>
            ammeter.MeasureCurrent(source.GetVoltage(), resistor.GetResistance());

        public double GetVoltage() =>
            voltmeter.MeasureVoltage(source);
    }

}