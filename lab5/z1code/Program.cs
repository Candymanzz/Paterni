using System;
using CarFactory.Factories;
using CarFactory.Products;

namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car Factory Application");
            Console.WriteLine("----------------------");

            // Create Toyota factory
            ICarFactory toyotaFactory = new ToyotaFactory();
            Console.WriteLine("\nToyota Factory Production:");
            ProduceCars(toyotaFactory);

            // Create Honda factory
            ICarFactory hondaFactory = new HondaFactory();
            Console.WriteLine("\nHonda Factory Production:");
            ProduceCars(hondaFactory);
        }

        static void ProduceCars(ICarFactory factory)
        {
            // Create and display a sedan
            var sedan = factory.CreateSedan();
            Console.WriteLine($"\nSedan: {sedan.GetManufacturer()} {sedan.GetModel()}");
            Console.WriteLine($"Number of doors: {sedan.GetNumberOfDoors()}");

            // Create and display an SUV
            var suv = factory.CreateSUV();
            Console.WriteLine($"\nSUV: {suv.GetManufacturer()} {suv.GetModel()}");
            Console.WriteLine($"Has 4WD: {suv.HasFourWheelDrive()}");

            // Create and display a sports car
            var sportsCar = factory.CreateSportsCar();
            Console.WriteLine(
                $"\nSports Car: {sportsCar.GetManufacturer()} {sportsCar.GetModel()}"
            );
            Console.WriteLine($"Top speed: {sportsCar.GetTopSpeed()} km/h");
        }
    }
}
