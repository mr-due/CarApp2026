using System.Collections.Generic;
using System.IO;
using System.Linq;
using CarApp2026.Core.Models;

namespace CarApp2026.Core.Repositories;

public class FileCarRepository : ICarRepository
{
    private string _filePath;

    public FileCarRepository(string filePath)
    {
        _filePath = filePath;
    }

    public IEnumerable<Car> GetAll()
    {
        if (!File.Exists(_filePath)) return new List<Car>();

        var lines = File.ReadAllLines(_filePath);
        List<Car> cars = new();

        foreach (var line in lines)
        {
            var type = line.Split(',')[0];
            if (type == "FuelCar") cars.Add(FuelCar.FromString(line));
            if (type == "ElectricCar") cars.Add(ElectricCar.FromString(line));
        }
        return cars;
    }

    public Car GetByLicensePlate(string plate)
        => GetAll().FirstOrDefault(c => c.LicensePlate == plate);

    public void Add(Car car)
    {
        File.AppendAllText(_filePath, car.ToString() + System.Environment.NewLine);
    }

    public void Update(Car car)
    {
        var cars = GetAll().ToList();
        var existing = cars.FirstOrDefault(c => c.LicensePlate == car.LicensePlate);
        if (existing != null)
        {
            cars.Remove(existing);
            cars.Add(car);
            File.WriteAllLines(_filePath, cars.Select(c => c.ToString()));
        }
    }

    public void Delete(string plate)
    {
        var cars = GetAll().Where(c => c.LicensePlate != plate);
        File.WriteAllLines(_filePath, cars.Select(c => c.ToString()));
    }
}
