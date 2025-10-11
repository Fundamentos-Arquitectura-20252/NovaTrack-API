using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetUpcomingMaintenanceQuery(int DaysThreshold = 7) : IQuery<IEnumerable<MaintenanceRecordResource>>;
}