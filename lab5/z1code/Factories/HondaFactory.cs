using CarFactory.Products;

namespace CarFactory.Factories
{
    public class HondaFactory : ICarFactory
    {
        public ISedan CreateSedan()
        {
            return new HondaAccord();
        }

        public ISUV CreateSUV()
        {
            return new HondaCRV();
        }

        public ISportsCar CreateSportsCar()
        {
            return new HondaNSX();
        }
    }
}
