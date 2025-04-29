using System;

namespace z2code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Фабрика лекарственных препаратов");
            Console.WriteLine("--------------------------------");

            // Создаем фабрики
            MedicineFactory[] factories = new MedicineFactory[]
            {
                new AntibioticFactory(),
                new PainkillerFactory(),
                new VitaminFactory(),
            };

            // Производим лекарства с помощью фабрик
            foreach (var factory in factories)
            {
                Medicine medicine = factory.CreateMedicine();
                medicine.ShowInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
