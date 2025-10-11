using MediatR;
using NovaTrack.Personnel.Interfaces.REST.Resources;

namespace NovaTrack.Personnel.Domain.Model.Queries
{
    public record GetDriverByIdQuery(int DriverId) : IRequest<DriverResource?>;
}