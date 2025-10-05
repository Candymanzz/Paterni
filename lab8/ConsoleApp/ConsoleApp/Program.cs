using System;
using ClassLibary;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var store = new Store();

            // Добавляем товары
            var p1 = new Product("Кружка", 7.5m, 10);
            var p2 = new Product("Блокнот", 3.0m, 20);
            store.AddProduct(p1);
            store.AddProduct(p2);

            // Добавляем продавцов
            var s1 = new SalesPerson("Иван", "Иванов", 0.5m);
            var s2 = new SalesPerson("Мария", "Петрова", 0.7m);
            store.AddSalesPerson(s1);
            store.AddSalesPerson(s2);

            // Продажа
            if (store.SellProduct(p1.Id, 2, s1.Id, out var err1))
                Console.WriteLine("Продажа выполнена: 2 x Кружка Иваном");
            else
                Console.WriteLine("Ошибка продажи: " + err1);

            store.SellProduct(p2.Id, 5, s2.Id, out var err2);

            // Информация: какие товары проданы сотрудником s2
            var salesByS2 = store.GetSalesBySalesPerson(s2.Id);
            Console.WriteLine($"Продажи {s2.FullName}:");
            foreach (var sale in salesByS2)
                Console.WriteLine($" - {sale.Quantity} x {sale.ProductName} за {sale.TotalPrice} ({sale.Date})");

            // Общая выручка
            Console.WriteLine($"Общая выручка: {store.GetTotalRevenue()}");

            // Зарплата s1 (предположим базовая 300)
            Console.WriteLine($"{s1.FullName} продал(а) {s1.GetSoldCount(store)} единиц. Зарплата: {s1.CalculateSalary(300m, store)}");

            // Сохранение/загрузка
            var path = "store_data.xml";
            store.SaveToXml(path);
            Console.WriteLine($"Данные сохранены в {path}");

            var loaded = Store.LoadFromXml(path);
            Console.WriteLine($"Загружено товаров: {loaded.Products.Count}, продаж: {loaded.Sales.Count}");
        }
    }
}