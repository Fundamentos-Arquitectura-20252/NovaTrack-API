namespace NovaTrack.FleetManagement.Interfaces.REST.Resources
{
    public record AssignVehicleToFleetResource(
        int FleetId
    );
    
    public record AssignVehicleToDriverResource(
        int DriverId
    );
}
