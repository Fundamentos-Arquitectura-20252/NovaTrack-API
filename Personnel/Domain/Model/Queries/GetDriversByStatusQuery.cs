using Flota365.Platform.API.Personnel.Domain.Model.Aggregates;
using MediatR;
using Flota365.Platform.API.Personnel.Interfaces.REST.Resources;
using Flota365.Platform.API.Personnel.Domain.Model.ValueObjects;

namespace Flota365.Platform.API.Personnel.Domain.Model.Queries
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