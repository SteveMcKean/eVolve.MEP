namespace eVolve.MEP;


/// <summary>
/// This isn't optimal, but it's a start. Should if time permitted, separate the concerns of the garage and lot. 
/// </summary>
public interface IGarage
{
    bool HasCompactParking { get; }
    int? MaxWeight { get; }
    int GetAvailableCompactSpaces();
    void AssignVehicle(IVehicle vehicle);
}