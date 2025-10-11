using MediatR;
using NovaTrack.Personnel.Domain.Repositories;
using NovaTrack.Personnel.Domain.Model.Queries;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Interfaces.REST.Transform;

namespace NovaTrack.Personnel.Application.Internal.QueryServices
{
    public class GetDriversByStatusQueryHandler : IRequestHandler<GetDriversByStatusQuery, IEnumerable<DriverResource>>
    {
        private readonly IDriverRepository _driverRepository;

        public GetDriversByStatusQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<DriverResource>> Handle(GetDriversByStatusQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.FindByStatusAsync(request.Status);
            return drivers.Select(DriverResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}