using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record UpdateServiceRecordCommand(
int ServiceRecordId,
string Description,
decimal Cost,
string ServiceProvider,
string TechnicianName,
ServiceQuality Quality,
string PartsUsed,
string Notes
) : ICommand<bool>;
}