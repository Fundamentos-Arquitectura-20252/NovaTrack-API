using NovaTrack.Shared.Domain.Model;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record RescheduleMaintenanceCommand(
int MaintenanceId,
DateTime NewScheduledDate,
string Reason
) : ICommand<bool>;
}