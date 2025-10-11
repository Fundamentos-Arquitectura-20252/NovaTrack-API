using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

// GetFleetByIdQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetFleetByIdQueryHandler : IRequestHandler<GetFleetByIdQuery, FleetResource?>
    {
        private readonly IFleetRepository _fleetRepository;

        public GetFleetByIdQueryHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<FleetResource?> Handle(GetFleetByIdQuery request, CancellationToken cancellationToken)
        {
            var fleet = await _fleetRepository.FindByIdWithVehiclesAsync(request.FleetId);
            return fleet != null ? FleetResourceFromEntityAssembler.ToResourceFromEntity(fleet) : null;
        }
    }
}
