using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApp
{
    // Контейнеризируемый класс
    public class Faculty
    {
        public string Name { get; set; }
        public string Dean { get; set; }
        public int NumberOfStudents { get; set; }

        public Faculty(string name, string dean, int students)
        {
            Name = name;
            Dean = dean;
            NumberOfStudents = students;
        }

        public string GetInfo()
        {
            return $"Факультет: {Name}, Декан: {Dean}, Студентов: {NumberOfStudents}";
        }
    }

    // Контейнер (Singleton)
    public class University
    {
        private static University _instance;           // единственный экземпляр
        private List<Faculty> _faculties = new();      // контейнер
        public string Name { get; set; }

        private University(string name)
        {
            Name = name;
        }

        // Точка доступа к экземпляру
        public static University Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new University("Национальный Университет");
                return _instance;
            }
        }

        public void AddFaculty(Faculty f) => _faculties.Add(f);

        public void RemoveFaculty(string name)
        {
            var f = _faculties.FirstOrDefault(x => x.Name == name);
            if (f != null) _faculties.Remove(f);
        }

        public Faculty GetFaculty(string name) => _faculties.FirstOrDefault(x => x.Name == name);

        public void ShowAllFaculties()
        {
            Console.WriteLine($"Университет: {Name}");
            foreach (var f in _faculties)
                Console.WriteLine(f.GetInfo());
        }
    }

    // Демонстрация
    class Program
    {
        static void Main()
        {
            University uni = University.Instance; // Singleton
            uni.AddFaculty(new Faculty("Факультет ИТ", "Иванов И.И.", 500));
            uni.AddFaculty(new Faculty("Факультет Экономики", "Петров П.П.", 300));

            uni.ShowAllFaculties();

            Console.WriteLine("\nУдаляем факультет Экономики...\n");
            uni.RemoveFaculty("Факультет Экономики");

            uni.ShowAllFaculties();
        }
    }
}
