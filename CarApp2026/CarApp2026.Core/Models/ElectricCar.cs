namespace CarApp2026.Core.Models;

public class ElectricCar : Car, ISellable, IInsurable
{
    public double BatteryCapacity { get; private set; }
    public double BatteryLevel { get; private set; }
    public double KmPerKwh { get; private set; }
    public double Price { get; private set; }

    public ElectricCar(string brand, string model, int year, string licensePlate,
        double batteryCapacity, double kmPerKwh, double price)
        : base(brand, model, year, licensePlate)
    {
        BatteryCapacity = batteryCapacity;
        KmPerKwh = kmPerKwh;
        BatteryLevel = batteryCapacity;
        Price = price;
    }

    public override void UpdateEnergyLevel(double km)
    {
        BatteryLevel -= km / KmPerKwh;
    }

    public string GetSalesSummary() => $"{Brand} {Model} - {Price}";
    public double GetInsuranceRate() => 1.8;

    public override string ToString()
    {
        return $"ElectricCar,{Brand},{Model},{Year},{LicensePlate},{BatteryCapacity},{KmPerKwh},{Price}";
    }

    public static ElectricCar FromString(string data)
    {
        var p = data.Split(',');
        return new ElectricCar(p[1], p[2], int.Parse(p[3]), p[4],
            double.Parse(p[5]), double.Parse(p[6]), double.Parse(p[7]));
    }
}
