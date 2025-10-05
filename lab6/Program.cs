using lab6.AdapterLibrary;
using lab6.FacadeLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("== Адаптер ==");
        var charge = new PointCharge { q = 2.0, x = 1.0, y = 1.0 };
        IObject adapter = new PointChargeAdapter(charge);

        adapter.Move(2.0, -1.0);
        Console.WriteLine(adapter.GetData());
        Console.WriteLine($"Force = {adapter.CalculateForce(1.0, 2.0, 0.0)}");

        Console.WriteLine("\n== Фасад ==");
        var circuit = new ElectricalCircuitFacade(12.0, 4.0);
        Console.WriteLine($"Voltage: {circuit.GetVoltage()} V");
        Console.WriteLine($"Current: {circuit.GetCurrent()} A");
    }
}
