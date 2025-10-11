using NovaTrack.Shared.Domain.Model;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;

// Fleet Queries
namespace NovaTrack.FleetManagement.Domain.Model.Queries
{
    public record GetAllFleetsQuery() : IQuery<IEnumerable<FleetResource>>;
    
    public record GetFleetByIdQuery(int FleetId) : IQuery<FleetResource?>;
    
    public record GetActiveFleetQuery() : IQuery<IEnumerable<FleetResource>>;
    
    public record GetFleetByTypeQuery(string Type) : IQuery<IEnumerable<FleetResource>>;
    
}