using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetMaintenanceByTypeQuery(MaintenanceType Type) : IQuery<IEnumerable<MaintenanceRecordResource>>;
}