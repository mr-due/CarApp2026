using System.Collections.Generic;
using System.Linq;
using CarApp2026.Core.Models;

namespace CarApp2026.Core.Repositories;


public class InMemoryCarRepository : ICarRepository
{
    private List<Car> _cars = new();

    public IEnumerable<Car> GetAll() => _cars;

    public Car GetByLicensePlate(string plate)
        => _cars.FirstOrDefault(c => c.LicensePlate == plate);

    public void Add(Car car)
    {
        if (GetByLicensePlate(car.LicensePlate) != null)
            throw new System.Exception("Bil findes allerede");
        _cars.Add(car);
    }

    public void Update(Car car)
    {
        Delete(car.LicensePlate);
        Add(car);
    }

    public void Delete(string plate)
    {
        var car = GetByLicensePlate(plate);
        if (car != null) _cars.Remove(car);
    }
}
