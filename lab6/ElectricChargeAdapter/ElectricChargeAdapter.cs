namespace ElectricChargeAdapter
{
    public class ElectricChargeObjectAdapter : IElectricObject
    {
        private ElectricCharge _charge;

        public ElectricChargeObjectAdapter(ElectricCharge charge)
        {
            _charge = charge;
        }

        public void Move(double dx, double dy)
        {
            _charge.X += dx;
            _charge.Y += dy;
        }

        public double CalculateForces(double q, double r, double a)
        {
            // Преобразуем полярные координаты в декартовы
            double x = r * System.Math.Cos(a);
            double y = r * System.Math.Sin(a);

            // Вычисляем расстояние между зарядами
            double distance = System.Math.Sqrt(
                System.Math.Pow(x - _charge.X, 2) + System.Math.Pow(y - _charge.Y, 2)
            );

            return _charge.F((int)q, distance);
        }

        public string GetData()
        {
            return $"Заряд: {_charge.Q} Кл, X: {_charge.X}, Y: {_charge.Y}";
        }
    }
}
