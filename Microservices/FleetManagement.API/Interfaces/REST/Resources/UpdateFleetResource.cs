namespace NovaTrack.FleetManagement.Interfaces.REST.Resources
{
    public record UpdateFleetResource(
        string Name,
        string Description,
        string Type,
        bool IsActive
    );
}
