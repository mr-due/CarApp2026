using System.Collections.Generic;
using CarApp2026.Core.Models;

namespace CarApp2026.Core.Repositories;


public interface ICarRepository
{
    IEnumerable<Car> GetAll();
    Car GetByLicensePlate(string licensePlate);
    void Add(Car car);
    void Update(Car car);
    void Delete(string licensePlate);
}
