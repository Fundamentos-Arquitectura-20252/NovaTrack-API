using MediatR;
using NovaTrack.Personnel.Interfaces.REST.Resources;

namespace NovaTrack.Personnel.Domain.Model.Queries
{
    public class GetAvailableDriversQuery : IRequest<IEnumerable<DriverResource>>
    {
    }
}