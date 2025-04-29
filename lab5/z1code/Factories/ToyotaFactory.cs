using CarFactory.Products;

namespace CarFactory.Factories
{
    public class ToyotaFactory : ICarFactory
    {
        public ISedan CreateSedan()
        {
            return new ToyotaCamry();
        }

        public ISUV CreateSUV()
        {
            return new ToyotaRAV4();
        }

        public ISportsCar CreateSportsCar()
        {
            return new ToyotaSupra();
        }
    }
}
