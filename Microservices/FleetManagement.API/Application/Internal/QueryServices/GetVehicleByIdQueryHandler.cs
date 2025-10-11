using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

// GetVehicleByIdQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleResource?>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleResource?> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.FindByIdWithFleetAsync(request.VehicleId);
            return vehicle != null ? VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle) : null;
        }
    }
}
