using System;

namespace z2code
{
    // Абстрактный класс лекарственного препарата
    public abstract class Medicine
    {
        public string Name { get; protected set; }
        public string ActiveSubstance { get; protected set; }
        public decimal Price { get; protected set; }
        public string Form { get; protected set; }

        public abstract void ShowInfo();
    }

    // Конкретные реализации лекарственных препаратов
    public class Antibiotic : Medicine
    {
        public Antibiotic()
        {
            Name = "Амоксициллин";
            ActiveSubstance = "Амоксициллин тригидрат";
            Price = 150.50m;
            Form = "Таблетки";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Антибиотик: {Name}");
            Console.WriteLine($"Действующее вещество: {ActiveSubstance}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Форма выпуска: {Form}");
        }
    }

    public class Painkiller : Medicine
    {
        public Painkiller()
        {
            Name = "Ибупрофен";
            ActiveSubstance = "Ибупрофен";
            Price = 89.90m;
            Form = "Капсулы";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Обезболивающее: {Name}");
            Console.WriteLine($"Действующее вещество: {ActiveSubstance}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Форма выпуска: {Form}");
        }
    }

    public class Vitamin : Medicine
    {
        public Vitamin()
        {
            Name = "Аскорбиновая кислота";
            ActiveSubstance = "Витамин C";
            Price = 45.30m;
            Form = "Драже";
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Витамин: {Name}");
            Console.WriteLine($"Действующее вещество: {ActiveSubstance}");
            Console.WriteLine($"Цена: {Price} руб.");
            Console.WriteLine($"Форма выпуска: {Form}");
        }
    }
}
