using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record ScheduleMaintenanceCommand(
int VehicleId,
string Description,
MaintenanceType Type,
decimal EstimatedCost,
DateTime ScheduledDate,
string ServiceProvider,
int Priority = 3
) : ICommand<int>;
}