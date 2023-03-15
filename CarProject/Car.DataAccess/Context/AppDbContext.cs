using Car.Core.Entities;

namespace Car.DataAccess.Context;

public static class AppDbContext
{
    public static int vehicleCount=1;
    public static Vehicle[] vehicles = new Vehicle[vehicleCount];      
}
