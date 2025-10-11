using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetRecentServiceRecordsQuery(int DaysThreshold = 30) : IQuery<IEnumerable<ServiceRecordResource>>;
}