using Car.Business.Services;
using Car.Core.Entities;
using Car.DataAccess.Context;

//test
//Vehicle v1 = new Vehicle("10-KJ-100", "Mercedes", "M5", 20, "AI95", 60);
//Vehicle v2 = new Vehicle("11-KJ-101", "BMW", "M5", 30, "AI98", 70);

//CarServices services = new CarServices(v1);
//services.AddVehicle();


while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("0.Exit");
    Console.WriteLine("1.Add vehicle");
    Console.WriteLine("2.Get all vehicles");
    Console.WriteLine("Choose action:");

    int menu = int.Parse(Console.ReadLine());
    switch (menu)
    {
        case 0:
            System.Environment.Exit(0);
            break;
        case 1:
            //add vehicle
            Console.WriteLine("number:");
            string number = Console.ReadLine();
            Console.WriteLine("brand:");
            string brand = Console.ReadLine();
            Console.WriteLine("model:");
            string model = Console.ReadLine();
            Console.WriteLine("consumption:");
            double consumption = double.Parse(Console.ReadLine());
            Console.WriteLine("Fueltype:");
            string fueltype = Console.ReadLine();
            Console.WriteLine("Fuelcapacity:");
            int fuelCapacity = int.Parse(Console.ReadLine());


            Vehicle vehicle = new Vehicle(number, brand, model, consumption, fueltype, fuelCapacity);
            CarServices service = new CarServices(vehicle);
            service.AddVehicle();


            break;
        case 2:
            CarServices service1 = new CarServices();
            service1.GetVehicles();
            break;
        default:
            Console.WriteLine("invalid choice");
            break;
    }

}





//Vehicle vehicle = new Vehicle("10-KJ-100","Mercedes","M5",20,"AI95",60);

//CarServices carServices = new(vehicle);

//Console.WriteLine(carServices.GetMaxDistance());

//Console.WriteLine(carServices.IsFuelEnough(301));
//Console.WriteLine(carServices.GetCurrentFuelLevel());
//carServices.Run(305);
//carServices.CalculateFuelCost(60);



#region ToDo
// Add menu with switch case
// Add new car
// Get all cars
#endregion