using System;
using System.Collections.Generic;
using System.Linq;

namespace ATCApp
{
    // 1️⃣ Интерфейс стратегии
    public interface ITariffCalc
    {
        double GetCost(double baseCost);
    }

    // 2️⃣ Конкретные стратегии
    public class RegularCalc : ITariffCalc
    {
        public double GetCost(double baseCost) => baseCost; // без изменений
    }

    public class DiscountCalc : ITariffCalc
    {
        private double discountPercent;
        public DiscountCalc(double discountPercent)
        {
            this.discountPercent = discountPercent;
        }

        public double GetCost(double baseCost)
        {
            return baseCost * (1 - discountPercent / 100.0);
        }
    }

    // 3️⃣ Класс тарифа
    public class Tariff
    {
        public string Name { get; }
        public double BaseCost { get; }
        private ITariffCalc calcStrategy;

        public Tariff(string name, double baseCost, ITariffCalc strategy)
        {
            Name = name;
            BaseCost = baseCost;
            calcStrategy = strategy;
        }

        public double GetFinalCost()
        {
            return calcStrategy.GetCost(BaseCost);
        }
    }

    // 4️⃣ Класс ATC — контейнер тарифов
    public class ATC
    {
        private List<Tariff> tariffs = new();

        public void AddTariff(Tariff tariff)
        {
            tariffs.Add(tariff);
        }

        public double GetAverageCost()
        {
            if (tariffs.Count == 0) return 0;
            return tariffs.Average(t => t.GetFinalCost());
        }

        public void ShowAllTariffs()
        {
            foreach (var t in tariffs)
                Console.WriteLine($"{t.Name} — {t.GetFinalCost():0.00} руб/мин");
        }
    }

    // 5️⃣ Демонстрация интерфейсов и Strategy
    class Program
    {
        static void Main()
        {
            ATC atc = new ATC();

            // Вызов метода интерфейса через ссылку
            ITariffCalc regular = new RegularCalc();
            ITariffCalc discount = new DiscountCalc(20); // 20% скидка

            // Создаём тарифы с разными стратегиями
            var t1 = new Tariff("Обычный тариф", 5.0, regular);
            var t2 = new Tariff("Льготный тариф", 5.0, discount);
            var t3 = new Tariff("Повышенный тариф", 7.0, regular);

            atc.AddTariff(t1);
            atc.AddTariff(t2);
            atc.AddTariff(t3);

            Console.WriteLine("Список тарифов:");
            atc.ShowAllTariffs();

            Console.WriteLine($"\nСредняя стоимость (с учетом скидок): {atc.GetAverageCost():0.00} руб/мин");

            // Демонстрация вызова метода интерфейса
            Console.WriteLine("\nПример вызова метода интерфейса через интерфейсную ссылку:");
            double testCost = 10;
            Console.WriteLine($"Обычный тариф: {regular.GetCost(testCost)}");
            Console.WriteLine($"Льготный тариф (-20%): {discount.GetCost(testCost)}");
        }
    }
}
