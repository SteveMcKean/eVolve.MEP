// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Xml;
using eVolve.MEP;

Console.WriteLine("Welcome to the Even Number Printer!");

Console.WriteLine();
EvenNumberPrinter.Print(17,4);

Console.WriteLine();
EvenNumberPrinter.Print(21,7);

Console.WriteLine();
EvenNumberPrinter.Print(20,5);

Console.WriteLine();
EvenNumberPrinter.Print(10,3);

Console.WriteLine();
EvenNumberPrinter.Print(2,2);

Console.WriteLine("Completed...");
// comment out the return for the Garage and Lot classes to run the rest of the code
return;

Console.WriteLine("Welcome to the Parking Garage!");

var car = new Car();
car.Weight = 4000;

var bus = new Bus();
bus.Weight = 6500;

var motorCycle = new MotorCycle();
motorCycle.Weight = 400;

var lot = new Lot();
var garage = new Garage(25);

var vehiclesList = new List<IVehicle> {car, bus, motorCycle};

try
{
    foreach (var vehicle in vehiclesList)
    {
        Console.WriteLine(FindAGarage(vehicle));
    }
}
catch (Exception exception)
{
    // TODO: handle exception
}

Console.WriteLine("Completed...");


IGarage? FindAGarage(IVehicle vehicle)
{
    // if the vehicle weight is > 1500 for the garage, return lot. can't take buses either
    if (vehicle.Weight > garage.MaxWeight || vehicle is Bus)
    {
        lot.AssignVehicle(vehicle);
        return lot;
    }
    
    // we know the weight is ok, can we check if there are compact spaces available?
    if (garage.HasCompactParking)
    {
        // how many do we have available?
        var availableSpaces = garage.GetAvailableCompactSpaces();
        if (availableSpaces > 0)
        {
            garage.AssignVehicle(vehicle);
            return garage;
        }
    }
    
    return null;
}
