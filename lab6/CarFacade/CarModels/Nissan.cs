namespace CarFacade.CarModels
{
    public class Nissan
    {
        public int Year { get; set; }
        public double EngineVolume { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;

        public Nissan()
        {
            Color = "белый";
            Equipment = "минимальная";
        }

        public double CalculatePrice()
        {
            double basePrice = 1200000;
            double yearFactor = (2024 - Year) * 40000;
            double engineFactor = EngineVolume * 80000;
            double equipmentFactor = Equipment switch
            {
                "минимальная" => 0,
                "средняя" => 150000,
                "максимальная" => 400000,
                _ => 0,
            };

            return basePrice - yearFactor + engineFactor + equipmentFactor;
        }
    }
}
