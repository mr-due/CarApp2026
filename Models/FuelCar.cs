namespace CarApp2026.Core.Models;

public class FuelCar : Car, ISellable
{
    public double TankCapacity { get; private set; }
    public double FuelLevel { get; private set; }
    public double KmPerLiter { get; private set; }
    public double Price { get; private set; }

    public FuelCar(string brand, string model, int year, string licensePlate,
        double tankCapacity, double kmPerLiter, double price)
        : base(brand, model, year, licensePlate)
    {
        TankCapacity = tankCapacity;
        KmPerLiter = kmPerLiter;
        FuelLevel = tankCapacity;
        Price = price;
    }

    public override void UpdateEnergyLevel(double km)
    {
        FuelLevel -= km / KmPerLiter;
    }

    public string GetSalesSummary() => $"{Brand} {Model} - {Price}";

    public override string ToString()
    {
        return $"FuelCar,{Brand},{Model},{Year},{LicensePlate},{TankCapacity},{KmPerLiter},{Price}";
    }

    public static FuelCar FromString(string data)
    {
        var p = data.Split(',');
        return new FuelCar(p[1], p[2], int.Parse(p[3]), p[4],
            double.Parse(p[5]), double.Parse(p[6]), double.Parse(p[7]));
    }
}
