namespace NovaTrack.Maintenance.Interfaces.REST.Resources
{
    public record UpdateServiceRecordResource(
        string Description,
        decimal Cost,
        string ServiceProvider,
        string TechnicianName,
        string Quality,
        string PartsUsed,
        string Notes
    );
}
