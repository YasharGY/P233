using Car.Business.Utilities;
using Car.Core.Entities;
using Car.DataAccess.Context;

namespace Car.Business.Services;

public class CarServices
{
    private Vehicle vehicle { get; set; }

    public CarServices()
    {

    }
    public CarServices(Vehicle vehicle)
    {
        this.vehicle = vehicle;
    }
    public double GetMaxDistance()
    {
        return (vehicle.CurrentFuelLevel / vehicle.Consumption) * 100;
    }

    public bool IsFuelEnough(int km)
    {
        double maxDistance = GetMaxDistance();
        return km <= maxDistance;
    }

    public double GetCurrentFuelLevel()
    {
        return vehicle.CurrentFuelLevel;
    }

    public void Run(int km)
    {
        if (km < 0)
        {
            Console.WriteLine("km must be more than zero");
        }
        double maxDistance = GetMaxDistance();
        if (km <= maxDistance)
        {
            vehicle.CurrentFuelLevel -= (vehicle.Consumption * km / 100);
            Console.WriteLine($"CurrentFuelLevel={vehicle.CurrentFuelLevel}");
            Console.WriteLine("Completed");
        }
        else
        {
            var restKm = km - maxDistance;
            var needFuel = (restKm * vehicle.Consumption) / 100;
            Console.WriteLine($"Need fuel: {needFuel} l");
        }
    }

    public void CalculateFuelCost(int l)
    {
        Helper.CalculateFuelCost(l, vehicle.FuelType);
    }

    public void AddVehicle()
    {
        if (AppDbContext.vehicles[0] == null)
        {
            AppDbContext.vehicles[0] = vehicle;
        }
        else
        {
            Vehicle[] tempVehicles = new Vehicle[AppDbContext.vehicles.Length];

            for (int i = 0; i < AppDbContext.vehicles.Length; i++)
            {
                tempVehicles[i] = AppDbContext.vehicles[i];
            }

            AppDbContext.vehicles = new Vehicle[AppDbContext.vehicles.Length + 1];
            for (int i = 0; i < tempVehicles.Length; i++)
            {
                AppDbContext.vehicles[i] = tempVehicles[i];
            }
            AppDbContext.vehicles[AppDbContext.vehicles.Length - 1] = vehicle;
        }



    }
    public void GetVehicles()
    {
        if (AppDbContext.vehicles[0] == null)
        {
            Console.WriteLine("Vehicle is not found");
            return;
        }


        for (int i = 0; i < AppDbContext.vehicles.Length; i++)
        {
            Console.WriteLine($"{i+1}.CAR:");
            Console.WriteLine($"Id:{AppDbContext.vehicles[i].Id}," +
                              $"Number:{AppDbContext.vehicles[i].Number}," +
                              $"Brand:{AppDbContext.vehicles[i].Brand}," +
                              $"Model:{AppDbContext.vehicles[i].Model}," +
                              $"Consumption:{AppDbContext.vehicles[i].Consumption}," +
                              $"FuelCapacity:{AppDbContext.vehicles[i].FuelCapacity}," +
                              $"FuelType:{AppDbContext.vehicles[i].FuelType}");
        }
    }

}
