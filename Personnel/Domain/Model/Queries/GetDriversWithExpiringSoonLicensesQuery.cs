using MediatR;
using Flota365.Platform.API.Personnel.Interfaces.REST.Resources;

namespace Flota365.Platform.API.Personnel.Domain.Model.Queries
{
    public record GetDriversWithExpiringSoonLicensesQuery(int DaysThreshold) 
        : IRequest<IEnumerable<DriverResource>>;
}