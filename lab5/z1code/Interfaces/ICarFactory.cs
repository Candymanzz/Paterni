using CarFactory.Products;

namespace CarFactory.Factories
{
    public interface ICarFactory
    {
        ISedan CreateSedan();
        ISUV CreateSUV();
        ISportsCar CreateSportsCar();
    }
}
