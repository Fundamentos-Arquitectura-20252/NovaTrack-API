using MediatR;
using NovaTrack.Personnel.Domain.Model.Queries;
using NovaTrack.Personnel.Domain.Repositories;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Interfaces.REST.Transform;

namespace NovaTrack.Personnel.Application.Internal.QueryServices
{
    public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<DriverResource>>
    {
        private readonly IDriverRepository _driverRepository;

        public GetAllDriversQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<DriverResource>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.ListAsync();
            return drivers.Select(DriverResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}