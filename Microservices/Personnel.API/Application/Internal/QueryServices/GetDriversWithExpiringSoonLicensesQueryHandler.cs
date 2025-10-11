using MediatR;
using NovaTrack.Personnel.Domain.Model.Queries;
using NovaTrack.Personnel.Domain.Repositories;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Interfaces.REST.Transform;

namespace NovaTrack.Personnel.Application.Internal.QueryServices
{
    public class GetDriversWithExpiringSoonLicensesQueryHandler : IRequestHandler<GetDriversWithExpiringSoonLicensesQuery, IEnumerable<DriverResource>>
    {
        private readonly IDriverRepository _driverRepository;

        public GetDriversWithExpiringSoonLicensesQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<DriverResource>> Handle(GetDriversWithExpiringSoonLicensesQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _driverRepository.FindDriversWithExpiringSoonLicensesAsync(request.DaysThreshold);
            return drivers.Select(DriverResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}