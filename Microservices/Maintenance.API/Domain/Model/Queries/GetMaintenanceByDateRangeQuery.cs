using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetMaintenanceByDateRangeQuery(DateTime StartDate, DateTime EndDate) : IQuery<IEnumerable<MaintenanceRecordResource>>;
}