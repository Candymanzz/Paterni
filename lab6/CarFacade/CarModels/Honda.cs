namespace CarFacade.CarModels
{
    public class Honda
    {
        public int Year { get; set; }
        public double EngineVolume { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;

        public Honda()
        {
            Color = "белый";
            Equipment = "минимальная";
        }

        public double CalculatePrice()
        {
            double basePrice = 1300000;
            double yearFactor = (2024 - Year) * 45000;
            double engineFactor = EngineVolume * 90000;
            double equipmentFactor = Equipment switch
            {
                "минимальная" => 0,
                "средняя" => 180000,
                "максимальная" => 450000,
                _ => 0,
            };

            return basePrice - yearFactor + engineFactor + equipmentFactor;
        }
    }
}
