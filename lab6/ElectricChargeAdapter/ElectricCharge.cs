namespace ElectricChargeAdapter
{
    public class ElectricCharge
    {
        public double Q { get; set; } // заряд
        public double X { get; set; } // координата X
        public double Y { get; set; } // координата Y

        public ElectricCharge(double q, double x, double y)
        {
            Q = q;
            X = x;
            Y = y;
        }

        public double F(int m, double r)
        {
            // Формула силы взаимодействия между зарядами
            const double k = 9e9; // электрическая постоянная
            return k * Q * m / (r * r);
        }
    }
}
