using System;
using System.Linq;
using CarApp2026.Core.Models;
using CarApp2026.Core.Repositories;

class Program
{
    static void Main()
    {
        ICarRepository repo = new InMemoryCarRepository();

        // TEST DATA
        var fuel = new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 18, 45000);
        var electric = new ElectricCar("Tesla", "Model 3", 2023, "CD67890", 75, 6.5, 380000);

        repo.Add(fuel);
        repo.Add(electric);

        // DRIVE (Trip usage)
        var trip1 = new Trip(fuel, 100, DateTime.Now.AddHours(-2), DateTime.Now);
        fuel.Drive(trip1);

        // CRUD TEST
        Console.WriteLine("Alle biler:");
		foreach (var car in repo.GetAll())
		{
			Console.WriteLine($"{car.Brand} {car.Model} — {car.LicensePlate}");
		}

		var found = repo.GetByLicensePlate("AB12345");
        Console.WriteLine(found != null ? "Fundet bil" : "Ikke fundet");

        repo.Update(new FuelCar("Toyota", "Corolla", 2022, "AB12345", 50, 20, 46000));

        repo.Delete("CD67890");

        Console.WriteLine($"Antal biler: {repo.GetAll().Count()}");

        // Interface usage
        ISellable sell = fuel;
        Console.WriteLine(sell.GetSalesSummary());
    }
}
