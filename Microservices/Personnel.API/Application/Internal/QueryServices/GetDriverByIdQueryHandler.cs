using MediatR;
using NovaTrack.Personnel.Domain.Model.Queries;
using NovaTrack.Personnel.Domain.Repositories;
using NovaTrack.Personnel.Interfaces.REST.Resources;
using NovaTrack.Personnel.Interfaces.REST.Transform;

namespace NovaTrack.Personnel.Application.Internal.QueryServices
{
    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverResource?>
    {
        private readonly IDriverRepository _driverRepository;

        public GetDriverByIdQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<DriverResource?> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            var driver = await _driverRepository.FindByIdAsync(request.DriverId);
            return driver != null ? DriverResourceFromEntityAssembler.ToResourceFromEntity(driver) : null;
        }
    }
}