using MediatR;
using NovaTrack.Personnel.Interfaces.REST.Resources;

namespace NovaTrack.Personnel.Domain.Model.Queries
{
    
    public record GetDriverStatsQuery() : IRequest<DriverStatsResource>;
}