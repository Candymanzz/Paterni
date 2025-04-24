using System;

// Interfaces following Interface Segregation Principle (ISP)
public interface IMovable
{
    void Move();
}

public interface IEnginePowered
{
    void StartEngine();
    void StopEngine();
}

public interface ISailPowered
{
    void RaiseSails();
    void LowerSails();
}

// Base class following Liskov Substitution Principle (LSP)
public abstract class Ship : IMovable
{
    public string Name { get; protected set; }
    public int YearBuilt { get; protected set; }

    protected Ship(string name, int yearBuilt)
    {
        Name = name;
        YearBuilt = yearBuilt;
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Name} is moving through water");
    }
}

// Concrete classes
public class Steamship : Ship, IEnginePowered
{
    public Steamship(string name, int yearBuilt)
        : base(name, yearBuilt) { }

    public void StartEngine()
    {
        Console.WriteLine($"{Name} is starting its steam engine");
    }

    public void StopEngine()
    {
        Console.WriteLine($"{Name} is stopping its steam engine");
    }

    public override void Move()
    {
        StartEngine();
        base.Move();
    }
}

public class Sailboat : Ship, ISailPowered
{
    public Sailboat(string name, int yearBuilt)
        : base(name, yearBuilt) { }

    public void RaiseSails()
    {
        Console.WriteLine($"{Name} is raising its sails");
    }

    public void LowerSails()
    {
        Console.WriteLine($"{Name} is lowering its sails");
    }

    public override void Move()
    {
        RaiseSails();
        base.Move();
    }
}

public class Corvette : Ship, IEnginePowered, ISailPowered
{
    public Corvette(string name, int yearBuilt)
        : base(name, yearBuilt) { }

    public void StartEngine()
    {
        Console.WriteLine($"{Name} is starting its engine");
    }

    public void StopEngine()
    {
        Console.WriteLine($"{Name} is stopping its engine");
    }

    public void RaiseSails()
    {
        Console.WriteLine($"{Name} is raising its sails");
    }

    public void LowerSails()
    {
        Console.WriteLine($"{Name} is lowering its sails");
    }

    public override void Move()
    {
        StartEngine();
        RaiseSails();
        base.Move();
    }
}

// Service class following Dependency Inversion Principle (DIP)
public class ShipService
{
    private readonly IMovable _ship;

    public ShipService(IMovable ship)
    {
        _ship = ship;
    }

    public void OperateShip()
    {
        _ship.Move();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create different types of ships
        var steamship = new Steamship("Titanic", 1912);
        var sailboat = new Sailboat("Black Pearl", 2003);
        var corvette = new Corvette("HMS Victory", 1765);

        // Demonstrate LSP - we can use any ship type with ShipService
        var steamshipService = new ShipService(steamship);
        var sailboatService = new ShipService(sailboat);
        var corvetteService = new ShipService(corvette);

        Console.WriteLine("Operating different types of ships:");
        Console.WriteLine("\nSteamship:");
        steamshipService.OperateShip();

        Console.WriteLine("\nSailboat:");
        sailboatService.OperateShip();

        Console.WriteLine("\nCorvette:");
        corvetteService.OperateShip();
    }
}
