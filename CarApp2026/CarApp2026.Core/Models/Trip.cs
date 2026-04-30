using System;

namespace CarApp2026.Core.Models;

public class Trip
{
    private readonly Car _car;

    public double Distance { get; private set; }
    public DateTime TripDate { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public Car Car => _car;

    public Trip(Car car, double distance, DateTime start, DateTime end)
    {
        _car = car;
        Distance = distance;
        StartTime = start;
        EndTime = end;
        TripDate = start.Date;
    }
}
