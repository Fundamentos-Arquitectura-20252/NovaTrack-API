using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record CreateServiceRecordCommand(
int VehicleId,
ServiceType ServiceType,
string Description,
decimal Cost,
DateTime ServiceDate,
int MileageAtService,
string ServiceProvider,
string TechnicianName,
string PartsUsed,
string Notes
) : ICommand<int>;
}