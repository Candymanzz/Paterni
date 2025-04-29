namespace ElectricChargeAdapter
{
    public interface IElectricObject
    {
        void Move(double dx, double dy);
        double CalculateForces(double q, double r, double a);
        string GetData();
    }
}
