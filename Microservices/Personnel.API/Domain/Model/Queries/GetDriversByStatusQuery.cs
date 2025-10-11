using NovaTrack.Personnel.Domain.Model.Aggregates;
using MediatR;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Domain.Model.ValueObjects;

namespace NovaTrack.Personnel.Domain.Model.Queries
{
    public class GetDriversByStatusQuery : IRequest<IEnumerable<DriverResource>>
    {
        public DriverStatus Status { get; }

        public GetDriversByStatusQuery(DriverStatus status)
        {
            Status = status;
        }
    }
}