namespace eVolve.MEP;

public interface IGarage
{
    bool HasCompactParking { get; }
    int? MaxWeight { get; }
    int GetAvailableCompactSpaces();
    void AssignVehicle(IVehicle vehicle);
}