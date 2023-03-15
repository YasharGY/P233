using Car.Core.Entities;

namespace Car.Business.Utilities;

public static class Helper
{
    public static double AI92 { get; set; }
    public static double AI95 { get; set; }
    public static double AI98 { get; set; }
    public static double Diesel { get; set; }

    static Helper()
    {
        AI92 = 1;
        AI95 = 2.3;
        AI98 = 2.8;
        Diesel = 0.8;
    }

    public static void CalculateFuelCost(int l,string fuelType)
    {
        double cost = 0;
        switch (fuelType)
        {
            case "AI92":
                cost = Helper.AI92 * l;
                break;
            case "AI95":
                cost = Helper.AI95 * l;
                break;
            case "AI98":
                cost = Helper.AI98 * l;
                break;
            default:
                cost = Helper.Diesel * l;
                break;
        }
        Console.WriteLine($"for {l} litre fuel you need {cost} Azn");
    }

}
