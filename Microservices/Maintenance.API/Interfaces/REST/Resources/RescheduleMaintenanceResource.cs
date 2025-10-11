namespace NovaTrack.Maintenance.Interfaces.REST.Resources
{
    public record RescheduleMaintenanceResource(
        DateTime NewScheduledDate,
        string Reason
    );
}
