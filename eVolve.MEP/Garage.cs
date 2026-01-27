using System.Xml;

namespace eVolve.MEP;

public class Garage : IGarage
{
    private int compactSpaces;
    private int usedSpaces;
    
    private readonly List<IVehicle> vehicles = [];

    public bool HasCompactParking { get; } = true;
    public int? MaxWeight { get; } = 1500;
    
    public Garage(int compactSpaces)
    {
        this.compactSpaces = compactSpaces;
    }

    public int GetAvailableCompactSpaces()
    {
        return  compactSpaces;
    }
    
    public void AssignVehicle(IVehicle vehicle)
    {
        if (vehicles.Count >= compactSpaces)
            throw new InvalidOperationException("Garage is full");

        usedSpaces++;
        vehicles.Add(vehicle);
    }

    public override string ToString()
    {
        return $"Garage with {compactSpaces} compact spaces. Occupancy: {vehicles.Count}, Remaining spaces: {compactSpaces - usedSpaces} Vehicles: {string.Join(", ", vehicles.Select(v => v.GetType().Name))}";
    }
}