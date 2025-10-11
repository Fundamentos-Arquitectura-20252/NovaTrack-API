using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record UpdateMaintenanceCommand(
int MaintenanceId,
string Description,
MaintenanceType Type,
decimal EstimatedCost,
DateTime ScheduledDate,
string ServiceProvider,
string Notes,
MaintenanceStatus Status
) : ICommand<bool>;
}