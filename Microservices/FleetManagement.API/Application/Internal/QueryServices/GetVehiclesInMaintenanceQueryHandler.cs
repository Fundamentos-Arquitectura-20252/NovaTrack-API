using NovaTrack.FleetManagement.Domain.Model.Aggregates;
using MediatR;
    using NovaTrack.FleetManagement.Domain.Model.Queries;
    using NovaTrack.FleetManagement.Domain.Repositories;
    using NovaTrack.FleetManagement.Interfaces.REST.Resources;
    using NovaTrack.FleetManagement.Interfaces.REST.Transform;
    
    namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
    {
        public class GetVehiclesInMaintenanceQueryHandler : IRequestHandler<GetVehiclesInMaintenanceQuery, IEnumerable<VehicleResource>>
        {
            private readonly IVehicleRepository _vehicleRepository;
    
            public GetVehiclesInMaintenanceQueryHandler(IVehicleRepository vehicleRepository)
            {
                _vehicleRepository = vehicleRepository;
            }
    
            public async Task<IEnumerable<VehicleResource>> Handle(GetVehiclesInMaintenanceQuery request, CancellationToken cancellationToken)
            {
                var vehicles = await _vehicleRepository.FindVehiclesInMaintenanceAsync();
                return vehicles.Select<Vehicle, VehicleResource>(vehicle => VehicleResourceFromEntityAssembler.ToResourceFromEntity(vehicle));
            }
        }
    }