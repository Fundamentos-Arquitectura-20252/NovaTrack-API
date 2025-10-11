using NovaTrack.Shared.Domain.Model;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
namespace NovaTrack.Maintenance.Domain.Model.Queries
{
public record GetMaintenanceCostAnalysisQuery(DateTime StartDate, DateTime EndDate) : IQuery<MaintenanceCostAnalysisResource>;
}