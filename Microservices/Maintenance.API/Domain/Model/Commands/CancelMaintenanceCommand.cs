using NovaTrack.Shared.Domain.Model;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record CancelMaintenanceCommand(
int MaintenanceId,
string Reason
) : ICommand<bool>;
}