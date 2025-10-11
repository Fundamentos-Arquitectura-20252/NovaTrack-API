using NovaTrack.Shared.Domain.Model;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record StartMaintenanceCommand(
int MaintenanceId
) : ICommand<bool>;
}