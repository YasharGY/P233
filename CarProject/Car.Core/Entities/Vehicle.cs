namespace Car.Core.Entities;

public class Vehicle:BaseEntity
{
    public string Number { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public double Consumption { get; set; }
    public string FuelType { get; set; }
    public int FuelCapacity { get; set; }
    public double CurrentFuelLevel { get; set; }
    public static int Counter { get;private set; }
    public Vehicle()
    {
        Counter++;
        Id=Counter;
    }

    public Vehicle(string number, 
        string brand, 
        string model,
        double consumption, 
        string fuelType, 
        int fuelCapacity) :this()
    {
        Number = number;
        Brand = brand;
        Model = model;
        Consumption = consumption;
        FuelType = fuelType;
        FuelCapacity = fuelCapacity;
        CurrentFuelLevel = fuelCapacity;
    }
}
