using CarFacade.CarModels;

namespace CarFacade
{
    public class CarFacade
    {
        private Toyota _toyota;
        private Honda _honda;
        private Nissan _nissan;

        public CarFacade()
        {
            _toyota = new Toyota();
            _honda = new Honda();
            _nissan = new Nissan();
        }

        public double GetToyotaPrice(int year, double engineVolume, string color, string equipment)
        {
            _toyota.Year = year;
            _toyota.EngineVolume = engineVolume;
            _toyota.Color = color;
            _toyota.Equipment = equipment;
            return _toyota.CalculatePrice();
        }

        public double GetHondaPrice(int year, double engineVolume, string color, string equipment)
        {
            _honda.Year = year;
            _honda.EngineVolume = engineVolume;
            _honda.Color = color;
            _honda.Equipment = equipment;
            return _honda.CalculatePrice();
        }

        public double GetNissanPrice(int year, double engineVolume, string color, string equipment)
        {
            _nissan.Year = year;
            _nissan.EngineVolume = engineVolume;
            _nissan.Color = color;
            _nissan.Equipment = equipment;
            return _nissan.CalculatePrice();
        }
    }
}
