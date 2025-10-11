using MediatR;
using NovaTrack.Personnel.Interfaces.REST.Resources;

namespace NovaTrack.Personnel.Domain.Model.Queries
{
    public record GetDriversWithExpiringSoonLicensesQuery(int DaysThreshold) 
        : IRequest<IEnumerable<DriverResource>>;
}