using System;
using System.Collections.Generic;

namespace CarApp2026.Core.Models;

public abstract class Car
{
    public string Brand { get; protected set; }
    public string Model { get; protected set; }
    public int Year { get; protected set; }
    public string LicensePlate { get; protected set; }

    public double Odometer { get; protected set; }

    protected List<Trip> _trips = new List<Trip>();

    public Car(string brand, string model, int year, string licensePlate)
    {
        Brand = brand;
        Model = model;
        Year = year;
        LicensePlate = licensePlate;
    }

    public virtual void Drive(Trip trip)
    {
        if (trip.Car == this)
        {
            Odometer += trip.Distance;
            UpdateEnergyLevel(trip.Distance);
            _trips.Add(trip);
        }
    }

    public List<Trip> GetTrips() => _trips;

    public List<Trip> GetTripsByDate(DateTime date)
    {
        List<Trip> result = new();
        foreach (var t in _trips)
            if (t.TripDate.Date == date.Date)
                result.Add(t);
        return result;
    }

    public List<Trip> GetTripsInInterval(DateTime start, DateTime end)
    {
        List<Trip> result = new();
        foreach (var t in _trips)
            if (t.StartTime >= start && t.EndTime <= end)
                result.Add(t);
        return result;
    }

    public abstract void UpdateEnergyLevel(double km);
}
