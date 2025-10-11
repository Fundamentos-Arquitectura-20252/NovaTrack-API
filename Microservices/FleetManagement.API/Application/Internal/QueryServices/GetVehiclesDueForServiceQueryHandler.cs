using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetVehiclesDueForServiceQueryHandler : IRequestHandler<GetVehiclesDueForServiceQuery, IEnumerable<VehicleResource>>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehiclesDueForServiceQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleResource>> Handle(GetVehiclesDueForServiceQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.FindVehiclesDueForServiceAsync();
            return vehicles.Select(VehicleResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}