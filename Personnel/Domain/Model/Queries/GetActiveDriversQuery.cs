using MediatR;
using System.Collections.Generic;
using Flota365.Platform.API.Personnel.Interfaces.REST.Resources;

namespace Flota365.Platform.API.Personnel.Domain.Model.Queries
{
    public record GetActiveDriversQuery() : IRequest<IEnumerable<DriverResource>>;
}