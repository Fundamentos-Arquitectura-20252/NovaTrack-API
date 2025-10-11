using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetServiceRecordsByProviderQuery(string ServiceProvider) : IQuery<IEnumerable<ServiceRecordResource>>;
}