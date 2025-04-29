namespace CarFactory.Products
{
    public interface ICar
    {
        string GetModel();
        string GetManufacturer();
    }

    public interface ISedan : ICar
    {
        int GetNumberOfDoors();
    }

    public interface ISUV : ICar
    {
        bool HasFourWheelDrive();
    }

    public interface ISportsCar : ICar
    {
        int GetTopSpeed();
    }
}
