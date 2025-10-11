using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

// GetActiveFleetQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetActiveFleetQueryHandler : IRequestHandler<GetActiveFleetQuery, IEnumerable<FleetResource>>
    {
        private readonly IFleetRepository _fleetRepository;

        public GetActiveFleetQueryHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<IEnumerable<FleetResource>> Handle(GetActiveFleetQuery request, CancellationToken cancellationToken)
        {
            var fleets = await _fleetRepository.FindActiveFleetAsync();
            return fleets.Select(FleetResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}
