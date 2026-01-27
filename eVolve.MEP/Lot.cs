namespace eVolve.MEP;

public class Lot : IGarage
{
    private readonly List<IVehicle> vehicles = [];
    
    bool IGarage.HasCompactParking { get; } = false;
    int? IGarage.MaxWeight { get; } = null;

    public int GetAvailableCompactSpaces()
    {
        return  0;
    }
    
    public void AssignVehicle(IVehicle vehicle)
    {
        if(vehicles.Contains(vehicle))
            return;
        
        vehicles.Add(vehicle);
    }
    
    public override string ToString()
    {
        return $"Lot: No compact spaces, Occupancy: {vehicles.Count}, Vehicles: {string.Join(", ", vehicles.Select(v => v.GetType().Name))}";
    }
}