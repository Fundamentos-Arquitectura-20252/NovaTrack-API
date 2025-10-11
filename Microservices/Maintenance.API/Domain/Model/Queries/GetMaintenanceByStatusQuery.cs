using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetMaintenanceByStatusQuery(MaintenanceStatus Status) : IQuery<IEnumerable<MaintenanceRecordResource>>;
}