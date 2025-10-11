using MediatR;
using System.Collections.Generic;
using NovaTrack.Personnel.Interfaces.REST.Resources;

namespace NovaTrack.Personnel.Domain.Model.Queries
{
    public record GetActiveDriversQuery() : IRequest<IEnumerable<DriverResource>>;
}