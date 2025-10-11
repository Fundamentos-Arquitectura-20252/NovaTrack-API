using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

// GetVehicleByLicensePlateQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetVehicleByLicensePlateQueryHandler : IRequestHandler<GetVehicleByLicensePlateQuery, VehicleResource?>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleByLicensePlateQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleResource?> Handle(GetVehicleByLicensePlateQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.FindByLicensePlateAsync(request.LicensePlate);
            return vehicle != null ? VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle) : null;
        }
    }
}
