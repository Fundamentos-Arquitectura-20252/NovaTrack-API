using MediatR;
using NovaTrack.Personnel.Domain.Model.Queries;
using NovaTrack.Personnel.Domain.Repositories;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Interfaces.REST.Transform;

namespace NovaTrack.Personnel.Application.Internal.QueryServices
{
    public class GetActiveDriversQueryHandler : IRequestHandler<GetActiveDriversQuery, IEnumerable<DriverResource>>
    {
        private readonly IDriverRepository _driverRepository;

        public GetActiveDriversQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<DriverResource>> Handle(GetActiveDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.FindActiveDriversAsync();
            return drivers.Select(DriverResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}