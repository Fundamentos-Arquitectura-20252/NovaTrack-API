using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

// GetVehiclesByFleetIdQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetVehiclesByFleetIdQueryHandler : IRequestHandler<GetVehiclesByFleetIdQuery, IEnumerable<VehicleResource>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesByFleetIdQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleResource>> Handle(GetVehiclesByFleetIdQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.FindByFleetIdAsync(request.FleetId);
            return vehicles.Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}
