namespace CarFactory.Products
{
    public class ToyotaCamry : ISedan
    {
        public string GetModel() => "Camry";

        public string GetManufacturer() => "Toyota";

        public int GetNumberOfDoors() => 4;
    }

    public class ToyotaRAV4 : ISUV
    {
        public string GetModel() => "RAV4";

        public string GetManufacturer() => "Toyota";

        public bool HasFourWheelDrive() => true;
    }

    public class ToyotaSupra : ISportsCar
    {
        public string GetModel() => "Supra";

        public string GetManufacturer() => "Toyota";

        public int GetTopSpeed() => 250;
    }
}
