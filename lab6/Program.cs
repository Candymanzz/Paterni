using CarFacade;
using ElectricChargeAdapter;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Демонстрация работы шаблона Адаптер:");
        Console.WriteLine("-----------------------------------");

        // Создаем точечный заряд
        var charge = new ElectricCharge(1.0, 0.0, 0.0);
        var adapter = new ElectricChargeObjectAdapter(charge);

        // Демонстрируем работу адаптера
        Console.WriteLine("Исходные данные заряда:");
        Console.WriteLine(adapter.GetData());

        Console.WriteLine("\nПеремещаем заряд:");
        adapter.Move(2.0, 3.0);
        Console.WriteLine(adapter.GetData());

        Console.WriteLine("\nРассчитываем силу взаимодействия:");
        double force = adapter.CalculateForces(2.0, 5.0, Math.PI / 4);
        Console.WriteLine($"Сила взаимодействия: {force:F2} Н");

        Console.WriteLine("\nДемонстрация работы шаблона Фасад:");
        Console.WriteLine("-----------------------------------");

        // Создаем фасад для работы с автомобилями
        var carFacade = new CarFacade.CarFacade();

        // Рассчитываем цены для разных автомобилей
        double toyotaPrice = carFacade.GetToyotaPrice(2022, 2.0, "красный", "максимальная");
        double hondaPrice = carFacade.GetHondaPrice(2021, 1.8, "синий", "средняя");
        double nissanPrice = carFacade.GetNissanPrice(2023, 1.6, "белый", "минимальная");

        Console.WriteLine($"Цена Toyota: {toyotaPrice:C}");
        Console.WriteLine($"Цена Honda: {hondaPrice:C}");
        Console.WriteLine($"Цена Nissan: {nissanPrice:C}");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
