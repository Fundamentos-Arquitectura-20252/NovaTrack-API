namespace NovaTrack.FleetManagement.Interfaces.REST.Resources
{
    public record CreateFleetResource(
        string Code,
        string Name,
        string Description,
        string Type
    );
}
