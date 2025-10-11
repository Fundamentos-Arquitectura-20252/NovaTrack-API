using MediatR;
using NovaTrack.Personnel.Domain.Repositories;
using NovaTrack.Personnel.Domain.Model.Queries;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Interfaces.REST.Transform;

namespace NovaTrack.Personnel.Application.Internal.QueryServices
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