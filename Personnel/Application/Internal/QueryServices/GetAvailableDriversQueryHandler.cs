using MediatR;
using Flota365.Platform.API.Personnel.Domain.Repositories;
using Flota365.Platform.API.Personnel.Domain.Model.Queries;
using Flota365.Platform.API.Personnel.Interfaces.REST.Resources;
using Flota365.Platform.API.Personnel.Interfaces.REST.Transform;

namespace Flota365.Platform.API.Personnel.Application.Internal.QueryServices
{
    public class GetAvailableDriversQueryHandler : IRequestHandler<GetAvailableDriversQuery, IEnumerable<DriverResource>>
    {
        private readonly IDriverRepository _driverRepository;

        public GetAvailableDriversQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<DriverResource>> Handle(GetAvailableDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.FindAvailableDriversAsync();
            return drivers.Select(DriverResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}