namespace CarFactory.Products
{
    public class HondaAccord : ISedan
    {
        public string GetModel() => "Accord";

        public string GetManufacturer() => "Honda";

        public int GetNumberOfDoors() => 4;
    }

    public class HondaCRV : ISUV
    {
        public string GetModel() => "CR-V";

        public string GetManufacturer() => "Honda";

        public bool HasFourWheelDrive() => true;
    }

    public class HondaNSX : ISportsCar
    {
        public string GetModel() => "NSX";

        public string GetManufacturer() => "Honda";

        public int GetTopSpeed() => 270;
    }
}
