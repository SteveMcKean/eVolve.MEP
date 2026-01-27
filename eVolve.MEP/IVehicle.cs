namespace eVolve.MEP;

public interface IVehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Length { get; set; }
    public int Weight { get; set; }
    public int MaxPassengers { get; set; }
}

// favor composition over inheritance