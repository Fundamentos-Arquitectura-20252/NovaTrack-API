namespace NovaTrack.Maintenance.Interfaces.REST.Resources
{
    public record CompleteMaintenanceResource(
        decimal ActualCost,
        string CompletionNotes
    );
}
